using IconTool.Helper;
using IconTool.Models;
using IconTool.Services.Interfaces;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IconTool.ViewModels.ModuleRight
{
    public class IconContentViewModel : BindableBase, IRegionMemberLifetime
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
        private string _tag = string.Empty;
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

        private string _colorType = string.Empty;
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

        private string _fromType = "-1";
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


        public DelegateCommand<int?> CopyPathCommand { get; private set; }

        public DelegateCommand<int?> ChangeCartCommand { get; private set; }
        public DelegateCommand<int?> RemoveCartCommand { get; private set; }

        public DelegateCommand<int?> ChangeCollectionCommand { get; private set; }

        public DelegateCommand ClearCartCommand { get; private set; }

        /// <summary>
        /// 下载素材
        /// </summary>
        public DelegateCommand DownloadMaterial { get; private set; }

        /// <summary>
        /// 下载代码
        /// </summary>
        public DelegateCommand DownloadCode { get; private set; }


        public bool KeepAlive => true;

        private readonly IIconService _iconService;
        private readonly ISetting _setting;

        public IconContentViewModel(IIconService iconService,ISetting setting)
        {
            _iconService = iconService;
            _setting = setting;
            CopyPathCommand = new DelegateCommand<int?>(OnClickCopyPath);
            ChangeCartCommand = new DelegateCommand<int?>(OnChangeCart);
            RemoveCartCommand = new DelegateCommand<int?>(OnRemoveCart);
            ChangeCollectionCommand = new DelegateCommand<int?>(OnCollectionChanged);
            ClearCartCommand = new DelegateCommand(OnClearCart);
            DownloadMaterial = new DelegateCommand(OnDownloadMaterial, CanDownload);
            DownloadCode = new DelegateCommand(OnDownloadCode, CanDownload);


            IconCarts.CollectionChanged += IconCarts_CollectionChanged;
            MyCollection.CollectionChanged += MyCollection_CollectionChanged;

            ///加载用户数据库
            if (_setting.IconCarts != null)
            {
                IconCarts.AddRange(_setting.IconCarts);
            }

            ///加载用户数据收藏夹
            if (_setting.MyCollection != null)
            {
                MyCollection.AddRange(_setting.MyCollection);
            }

            InitData();
        }

        private void OnRemoveCart(int? obj)
        {
            var icon = IconCarts.FirstOrDefault(x => x.Id == obj);
            if (icon != null) {
                IconCarts.Remove(icon);
                var iconItem = Items.FirstOrDefault(x => x.Id == obj);
                if (iconItem != null)
                {
                    iconItem.IsCollected = false;
                }
            }
        }

        private void OnDownloadCode()
        {
            _iconService.SaveSvgFiles();
        }

        private bool CanDownload()
        {
            return IconCarts.Count > 0;
        }

        private void OnDownloadMaterial()
        {
            _iconService.SaveFiles(IconCarts.Select(x => new SaveFileInfo() { Name = x.Name, Content = x.Origin_file, Suffix = ".svg", ID = x.Id }));
        }

        private void OnClearCart()
        {
            foreach (var item in IconCarts) {
                var iconItem = Items.FirstOrDefault(x => x.Id == item.Id);
                if (iconItem != null) {
                    iconItem.IsCollected = false;
                }
            }
            IconCarts.Clear();
        }

        private void MyCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _setting.MyCollection = MyCollection;
        }

        private void OnCollectionChanged(int? id)
        {
            var cartItem = Items.FirstOrDefault(x => x.Id == id);
            if (cartItem == null) {
                return;
            }
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
            DownloadMaterial.RaiseCanExecuteChanged();
            DownloadCode.RaiseCanExecuteChanged();
            _setting.IconCarts = IconCarts;
        }

        private void OnChangeCart(int? id)
        {
            var cartItem = Items.FirstOrDefault(x => x.Id == id);
            if (cartItem != null) {
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
        }


        private void InitData()
        {
            RefreshIcons();
        }

        private void RefreshIcons(int page = 1)
        {
            IsLoading = true;
            Task.Run(() =>
            {
                try
                {
                    var res = _iconService.GetList(SearchText, FromType, ColorType, Tag, page);
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
                                    Origin_file = icon.Origin_file,
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

        private void OnClickCopyPath(int? id)
        {
            _iconService.CopyXamlIcon("<Path Width=\"36\" Height=\"36\" Stretch=\"Uniform\" Fill=\"Black\" Data={0}\"></Path>",Items.FirstOrDefault(x=>x.Id == id).PrototypeSvg, _setting.IsCompress);
        }
    }
}
