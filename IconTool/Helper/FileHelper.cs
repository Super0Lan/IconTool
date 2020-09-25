using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IconTool.Helper
{
    public static class FileHelper
    {
        public static bool CreateFile(string path,string str) {
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            byte[] bytes = Encoding.Default.GetBytes(str);
            using (FileStream fileStream = new FileStream(path,FileMode.Create)) {
                fileStream.Write(bytes,0, bytes.Length);
                fileStream.Flush();
            }
            return true;
        }
    }
}
