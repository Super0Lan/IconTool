using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Models
{
    public class SaveFileInfo
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件内容
        /// </summary>
        public string Content { get; set; }


        public string Suffix { get; set; }

        public int ID { get; set; }

        /// <summary>
        /// 获取唯一值名字
        /// </summary>
        public string UniqueName { get { return $"{Name}-{ID}"; } }
    }
}
