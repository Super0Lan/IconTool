﻿using IconTool.Helper;
using IconTool.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IconTool.ViewModels
{
    public class MainWindowViewModel : BindableBase
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




        private string _searchText;
        public string SearchText { get { return _searchText; } set {
                if (SetProperty(ref _searchText, value)) {
                    RefreshIcons();
                }
            } 
        }

        private string _colorType;
        public string ColorType { get { return _colorType; } set 
            {
                if (SetProperty(ref _colorType, value)) {
                    RefreshIcons();
                }
            } 
        }

        private void RefreshIcons()
        {
            if (_isLoaded) {
                var res = HttpClientHelper.Post<ResultModel<IconCollection>>(SearchText, FromType, ColorType,Tag);
                if (res.IsSuccess)
                {
                    Items = res.Data.Icons;
                }
            }
        }

        private string _fromType;
        public string FromType { get { return _fromType; } set {
                if (SetProperty(ref _fromType, value)) {
                    RefreshIcons();
                }    
            } 
        }


        private List<IconItem> _items;
        public List<IconItem> Items { get { return _items; } set { SetProperty(ref _items, value); } }

        public DelegateCommand<string> CopyPathCommand { get; private set; }

        public ICommand LoadedCommand { get; private set; }

        public MainWindowViewModel()
        {
            CopyPathCommand = new DelegateCommand<string>(OnClickCopyPath);
            LoadedCommand = new DelegateCommand(OnLoaded);
        }
        private bool _isLoaded = false;

        private void OnLoaded()
        {
            _isLoaded = true;
            RefreshIcons();
        }

        private void OnClickCopyPath(string obj)
        {
            Clipboard.SetDataObject(string.IsNullOrEmpty(obj)? "": $"<Path Width=\"36\" Height=\"36\" Stretch=\"Uniform\" Fill=\"Black\" Data=\"{obj}\"></Path>");
        }
    }
}
