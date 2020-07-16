using IconTool.Helper;
using IconTool.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IconTool.ViewModels
{
    public class IconContentViewModel : BindableBase
    {
        public Dictionary<string, string> FromCollection { get; set; } = new Dictionary<string, string>() {
            { "所有图标","-1"},
            { "精选图标","1"},
        };

        public Dictionary<string, string> Fills { get; set; } = new Dictionary<string, string>() {
            { "所有颜色",string.Empty},
            { "多色图标","1"},
            { "单色图标","0"},
        };

        public Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>() {
            { "全部",string.Empty},
            { "线性","line"},
            { "面性","fill"},
            { "扁平","flat"},
            { "手绘","hand"},
            { "简约","simple"},
            { "精美","complex"},
        };

        #region 页面绑定属性
        private string _tag;
        public string Tag
        {
            get { return _tag; }
            set
            {
                if (SetProperty(ref _tag, value))
                {
                    RefreshIcons();
                }
            }
        }

        /// <summary>
        /// 总数量
        /// </summary>
        private int _count;
        public int Count { get { return _count; } set { SetProperty(ref _count, value); } }

        /// <summary>
        /// 当前页码
        /// </summary>
        private int _page = 1;
        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                SetProperty(ref _page, value, () =>
                {
                    RefreshIcons(value);
                });
            }
        }


        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    RefreshIcons();
                }
            }
        }

        private string _colorType;
        public string ColorType
        {
            get { return _colorType; }
            set
            {
                if (SetProperty(ref _colorType, value))
                {
                    RefreshIcons();
                }
            }
        }

        private string _fromType;
        public string FromType
        {
            get { return _fromType; }
            set
            {
                if (SetProperty(ref _fromType, value))
                {
                    RefreshIcons();
                }
            }
        }

        private bool _isLoading = false;
        public bool IsLoading { get { return _isLoading; } set { SetProperty(ref _isLoading, value); } }
        #endregion

        /// <summary>
        /// 库
        /// </summary>
        public ObservableCollection<IconItemViewModel> IconCarts { get; set; } = new ObservableCollection<IconItemViewModel>();

        /// <summary>
        /// 我的收藏
        /// </summary>
        public ObservableCollection<IconItemViewModel> MyCollection { get; set; } = new ObservableCollection<IconItemViewModel>();

        /// <summary>
        /// 图标集合
        /// </summary>
        public ObservableCollection<IconItemViewModel> Items { get; set; } = new ObservableCollection<IconItemViewModel>();


        public DelegateCommand<string> CopyPathCommand { get; private set; }

        public ICommand LoadedCommand { get; private set; }

        public DelegateCommand<int?> ChangeCartCommand { get; private set; }

        public DelegateCommand<int?> ChangeCollectionCommand { get; private set; }



        public IconContentViewModel()
        {
            CopyPathCommand = new DelegateCommand<string>(OnClickCopyPath);
            LoadedCommand = new DelegateCommand(OnLoaded);
            ChangeCartCommand = new DelegateCommand<int?>(OnChangeCart);
            ChangeCollectionCommand = new DelegateCommand<int?>(OnCollectionChanged);


            IconCarts.CollectionChanged += IconCarts_CollectionChanged;
            MyCollection.CollectionChanged += MyCollection_CollectionChanged;

            ///加载用户数据库
            if (!string.IsNullOrEmpty(Settings.Default.IconCarts))
            {
                IconCarts.AddRange(JsonConvert.DeserializeObject<List<IconItemViewModel>>(Settings.Default.IconCarts));
            }

            ///加载用户数据收藏夹
            if (!string.IsNullOrEmpty(Settings.Default.MyCollection))
            {
                MyCollection.AddRange(JsonConvert.DeserializeObject<List<IconItemViewModel>>(Settings.Default.MyCollection));
            }

        }

        private void MyCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Settings.Default.MyCollection = JsonConvert.SerializeObject(MyCollection);
        }

        private void OnCollectionChanged(int? id)
        {
            var cartItem = Items.FirstOrDefault(x => x.Id == id);
            cartItem.IsFavorite = !cartItem.IsFavorite;
            if (cartItem.IsFavorite)
            {
                MyCollection.Add(cartItem);
            }
            else
            {
                MyCollection.Remove(MyCollection.FirstOrDefault(x => x.Id == id));
            }
        }

        private void IconCarts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Settings.Default.IconCarts = JsonConvert.SerializeObject(IconCarts);
        }

        private void OnChangeCart(int? id)
        {
            var cartItem = Items.FirstOrDefault(x => x.Id == id);
            cartItem.IsCollected = !cartItem.IsCollected;
            if (cartItem.IsCollected)
            {
                IconCarts.Add(cartItem);
            }
            else
            {
                IconCarts.Remove(IconCarts.FirstOrDefault(x => x.Id == id));
            }
        }

        private bool _isLoaded = false;

        private void OnLoaded()
        {
            _isLoaded = true;
            RefreshIcons();
        }

        private void RefreshIcons(int page = 1)
        {
            if (_isLoaded)
            {
                IsLoading = true;
                Task.Run(() =>
                {
                    try
                    {
                        var res = HttpClientHelper.Post<ResultModel<IconCollection>>(SearchText, FromType, ColorType, Tag, page);
                        if (res.IsSuccess)
                        {
                            App.UIDispatcher.Invoke(() =>
                            {
                                Count = res.Data.Count;
                                Items.Clear();
                                foreach (var icon in res.Data.Icons)
                                {
                                    Items.Add(new IconItemViewModel()
                                    {
                                        Id = icon.Id,
                                        Name = icon.Name,
                                        PrototypeSvg = icon.Prototype_svg,
                                        IsCollected = IconCarts.Any(x => x.Id == icon.Id),
                                        IsFavorite = MyCollection.Any(x => x.Id == icon.Id),
                                    });
                                };
                                Page = page;
                            });

                        }
                    }
                    finally
                    {
                        App.UIDispatcher.Invoke(() =>
                        {
                            IsLoading = false;
                        });
                    }

                });
            }
        }

        private void OnClickCopyPath(string obj)
        {
            Clipboard.SetDataObject(string.IsNullOrEmpty(obj) ? "" : $"<Path Width=\"36\" Height=\"36\" Stretch=\"Uniform\" Fill=\"Black\" Data=\"{obj}\"></Path>");
        }
    }
}
