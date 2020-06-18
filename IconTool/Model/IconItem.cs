using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconTool.Model
{
    public class IconItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Svg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Origin_file { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Is_private { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Category_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Slug { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Unicode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Prototype_svg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Defs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Path_attributes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Fills { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Font_class { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int User_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Repositorie_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Updated_at { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Created_at { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Deleted_at { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Show_svg { get; set; }
    }

    public class IconCollection { 
        public List<IconItem> Icons { get; set; }

        public int Count { get; set; }
    }
}
