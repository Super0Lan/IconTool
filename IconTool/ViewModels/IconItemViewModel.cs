using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.ViewModels
{
    public class IconItemViewModel: BindableBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        private bool _isCollected = false;
        /// <summary>
        /// 是否添加入库
        /// </summary>
        public bool IsCollected { get { return _isCollected; } set { SetProperty(ref _isCollected, value); } }

        public string PrototypeSvg { get; set; }


        private bool _isFavorite = false;
        /// <summary>
        /// 是否收藏
        /// </summary>
        public bool IsFavorite { get { return _isFavorite; } set { SetProperty(ref _isFavorite, value); } }
    }
}
