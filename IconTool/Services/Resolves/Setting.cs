using IconTool.Services.Interfaces;
using IconTool.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Services.Resolves
{
    public class Setting : ISetting
    {
        public IEnumerable<IconItemViewModel> IconCarts 
        { 
            get => JsonConvert.DeserializeObject<IEnumerable<IconItemViewModel>>(Settings.Default.IconCarts);
            set => Settings.Default.IconCarts = JsonConvert.SerializeObject(value); 
        }
        public IEnumerable<IconItemViewModel> MyCollection 
        { 
            get => JsonConvert.DeserializeObject<IEnumerable<IconItemViewModel>>(Settings.Default.MyCollection); 
            set => Settings.Default.IconCarts = JsonConvert.SerializeObject(value);
        }
        public bool IsCompress 
        { 
            get => Settings.Default.IsCompress;
            set => Settings.Default.IsCompress = value; 
        }
        public string DefaultCodeTemplate 
        { 
            get => Settings.Default.DefaultCodeTemplate; 
            set => Settings.Default.DefaultCodeTemplate = value;
        }
        public string UserCodeTemplate 
        {
            get => string.IsNullOrEmpty(Settings.Default.UserCodeTemplate) ? Settings.Default.DefaultCodeTemplate : Settings.Default.UserCodeTemplate; 
            set => Settings.Default.UserCodeTemplate = value;
        }
    }
}
