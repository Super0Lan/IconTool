using IconTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Services.Interfaces
{
    public interface ISetting
    {
        /// <summary>
        /// 图标库
        /// </summary>
        IEnumerable<IconItemViewModel> IconCarts { get; set; }

        /// <summary>
        /// 图标收藏夹
        /// </summary>
        IEnumerable<IconItemViewModel> MyCollection { get; set; }

        /// <summary>
        /// Svg路径是否开启压缩
        /// </summary>
        bool IsCompress { get; set; }

        string DefaultCodeTemplate { get; set; }

        string UserCodeTemplate { get; set; }
    }
}
