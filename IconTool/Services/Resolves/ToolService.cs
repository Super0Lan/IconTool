using IconTool.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconTool.Services.Resolves
{
    public class ToolService : IToolService
    {
        private readonly string beginStr = "#begin#";
        private readonly string endStr = "#end#";
        private readonly string keyStr = "{name}";
        private readonly string valueStr = "{path}";

        public string GetCodeByTemplate(string codeTemplate, Dictionary<string, string> pairs)
        {
            if (!codeTemplate.Contains(beginStr)
                || !codeTemplate.Contains(endStr)
                || !codeTemplate.Contains(keyStr)
                || !codeTemplate.Contains(valueStr)
                ) {
                return "模板中缺少必要的占位符！";
            }
            StringBuilder sb = new StringBuilder();
            int beginIdx = codeTemplate.IndexOf(beginStr);
            int loopIdx = beginIdx + beginStr.Length;
            int endIdx = codeTemplate.IndexOf(endStr, beginIdx);
            string loopContent = codeTemplate.Substring(loopIdx, endIdx - loopIdx);
            sb.Append(codeTemplate.Substring(0, beginIdx));
            foreach (var temp in pairs) {
                sb.Append(loopContent.Replace(keyStr, temp.Key).Replace(valueStr, temp.Value));
            }
            sb.Append(codeTemplate.Substring(endIdx + endStr.Length));
            return sb.ToString();
        }
    }
}
