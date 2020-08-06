using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Services.Interfaces
{
    public interface IToolService
    {
        /// <summary>
        /// 根据数据和模板生成代码示例
        /// </summary>
        /// <param name="codeTemplate">代码模板</param>
        /// <param name="pairs">数据值</param>
        /// <returns>生成的代码</returns>
        string GetCodeByTemplate(string codeTemplate, Dictionary<string, string> pairs);
    }
}
