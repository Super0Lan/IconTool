using IconTool.Helper;
using IconTool.Models;
using IconTool.Services.Interfaces;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void SaveFiles(IEnumerable<SaveFileInfo> enumerable)
        {
            string path = string.Empty;
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    path = dialog.FileNames.FirstOrDefault();
                }
            }
            if (Directory.Exists(path)) {
                Parallel.ForEach(enumerable, (item) =>
                {
                    string fileName = Path.Combine(path, $"{item.UniqueName}{item.Suffix}");
                    FileHelper.CreateFile(fileName,item.Content);
                });
            }
        }

        public void SaveFile(SaveFileInfo fileInfo) {
            SaveFiles(new List<SaveFileInfo>() { fileInfo });
        }
    }
}
