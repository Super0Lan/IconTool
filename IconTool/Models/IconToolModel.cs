using IconTool.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Models
{
    public class IconToolModel
    {
        public EnumIcon Icon { get; set; }

        public EnumIcon SelectedIcon { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }
    }
}
