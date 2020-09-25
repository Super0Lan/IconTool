using IconTool.Helper;
using IconTool.Models;
using IconTool.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace IconTool.Services.Resolves
{
    public class IconService : IIconService
    {
        public void CopyXamlIcon(string template,string obj,bool isCompressed = false)
        {
            Clipboard.SetDataObject(string.IsNullOrEmpty(obj) ? "" : string.Format(template, Common.GetPathBySvgData(obj, isCompressed)));
        }

        public void CopyXamlIcon()
        {
            throw new NotImplementedException();
        }

        public ResultModel<IconCollection> GetList(string searchText,string fromType,string colorType,string tag,int page = 1 ,int pageSize = 30)
        {
            return HttpClientHelper.Post<ResultModel<IconCollection>>(searchText, fromType, colorType, tag, page,pageSize);
        }

        public void SaveSvgFiles()
        {
            
        }
    }
}
