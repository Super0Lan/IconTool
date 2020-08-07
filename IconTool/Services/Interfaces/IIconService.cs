using IconTool.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Services.Interfaces
{
    public interface IIconService
    {
        ResultModel<IconCollection> GetList(string searchText, string fromType, string colorType, string tag, int page = 1, int pageSize = 30);

        void SaveSvgFiles();

        /// <summary>
        /// 设置粘贴板内容
        /// </summary>
        /// <param name="template">模板</param>
        /// <param name="obj">内容</param>
        /// <param name="isCompressed">是否开启压缩</param>
        void CopyXamlIcon(string template, string obj, bool isCompressed = false);
    }
}
