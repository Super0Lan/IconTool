using IconTool.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Services.Interfaces
{
    public interface IIconService
    {
        ResultModel<IconCollection> GetList(string searchText, string fromType, string colorType, string tag, int page = 1, int pageSize = 30);
    }
}
