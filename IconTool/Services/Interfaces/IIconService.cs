﻿using IconTool.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Services.Interfaces
{
    public interface IIconService
    {
        /// <summary>
        /// 获取图标集合
        /// </summary>
        /// <param name="searchText">图标名称</param>
        /// <param name="fromType"></param>
        /// <param name="colorType"></param>
        /// <param name="tag"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        ResultModel<IconCollection> GetList(string searchText, string fromType, string colorType, string tag, int page = 1, int pageSize = 30);

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="enumerable"></param>
        void SaveFiles(IEnumerable<SaveFileInfo> enumerable);

        /// <summary>
        /// 保存单个文件
        /// </summary>
        /// <param name="enumerable"></param>
        void SaveFile(SaveFileInfo enumerable);

        /// <summary>
        /// 设置粘贴板内容
        /// </summary>
        /// <param name="template">模板</param>
        /// <param name="obj">内容</param>
        /// <param name="isCompressed">是否开启压缩</param>
        void CopyXamlIcon(string template, string obj, bool isCompressed = false);
    }
}
