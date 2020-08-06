using IconTool.Helper;
using IconTool.Models;
using IconTool.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Services.Resolves
{
    public class IconService : IIconService
    {
        public ResultModel<IconCollection> GetList(string searchText,string fromType,string colorType,string tag,int page = 1 ,int pageSize = 30)
        {
            return HttpClientHelper.Post<ResultModel<IconCollection>>(searchText, fromType, colorType, tag, page,pageSize);
        }
    }
}
