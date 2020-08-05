using IconTool.Helper;
using IconTool.Services.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IconTool.ViewModels.ModuleSetting
{
    public class GeneralSettingViewModel: BindableBase
    {
        private ISetting _setting;
        private IToolServices _toolServices;

        #region 是否开始代码压缩
        private bool _isCompress;
        public bool IsCompress 
        { 
            get { return _isCompress; } 
            set { 
                SetProperty(ref _isCompress, value);
                _setting.IsCompress = value;
            } 
        }
        #endregion

        private string _codeTemplate;
        public string CodeTemplate 
        { 
            get { return _codeTemplate; } 
            set 
            {
                if (SetProperty(ref _codeTemplate, value)) {
                    CodeInstance = _toolServices.GetCodeByTemplate(value, 
                        new Dictionary<string, string>(IconDataFactory.IconDic.TakeLast(10).ToDictionary(x=>x.Key.ToString(),y=>y.Value)));
                } 
            } 
        }

        private string _codeInstance;
        public string CodeInstance { get { return _codeInstance; } set { SetProperty(ref _codeInstance, value); } }

        public GeneralSettingViewModel(ISetting setting,IToolServices toolServices) {
            _setting = setting;
            _toolServices = toolServices;
            IsCompress = _setting.IsCompress;
            CodeTemplate = _setting.UserCodeTemplate;
        }
    }
}
