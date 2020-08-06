using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IconTool.Helper
{
    public static class HttpClientHelper
    {
        public static T Post<T>(string param,string fromCollection = "-1",string colorType = "",string tag= null,int currentPage = 1,int pageSize =30) {
            using (var client = HttpClientFactory.Create())
            {
                client.DefaultRequestHeaders.Add("authority", "www.iconfont.cn");
                client.DefaultRequestHeaders.Add("accept", "application/json, text/javascript, */*; q=0.01");
                client.DefaultRequestHeaders.Add("x-csrf-token", "1dYB-tMJpFsR7TGWWz-p1xRy");
                client.DefaultRequestHeaders.Add("x-requested-with", "XMLHttpRequest");
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.129 Safari/537.36");
                client.DefaultRequestHeaders.Add("origin", "https://www.iconfont.cn");
                client.DefaultRequestHeaders.Add("sec-fetch-site", "same-origin");
                client.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
                client.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
                client.DefaultRequestHeaders.Add("referer", "https://www.iconfont.cn/search/index?searchType=icon^&q=" + param);
                client.DefaultRequestHeaders.Add("accept-language", "zh-CN,zh;q=0.9");
                client.DefaultRequestHeaders.Add("cookie", "cna=C1U5F7VqIHgCAXQYQ7wsnTwD; trace=AQAAANC/kCIougMASkMYdLVSl+o4pJI2; ctoken=1dYB-tMJpFsR7TGWWz-p1xRy; isg=BLe3WLq5pWSariHrH-rQYsDvRqsBfIvex4YwuglkwAbtuNf6EUzWLoqamhjmUGNW");
                var paramDic = new Dictionary<string, string>{
                        { "q",string.IsNullOrEmpty(param) ? "iconfont":param},
                        { "sortType","updated_at"},
                        { "page",currentPage.ToString()},
                        { "pageSize",pageSize.ToString()},
                        { "fromCollection",fromCollection},
                        { "fills",colorType},
                        { "t",ConvertDateTimeToInt().ToString()},
                        { "ctoken","1dYB-tMJpFsR7TGWWz-p1xRy"},
                };
                if (!string.IsNullOrEmpty(tag)) {
                    paramDic.Add(tag, "1");
                }
                FormUrlEncodedContent content = new FormUrlEncodedContent(paramDic);
                var response = client.PostAsync("https://www.iconfont.cn/api/icon/search.json", content);
                var res = response.Result;
                if (res.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(res.Content.ReadAsStringAsync().Result);
                }
                return default;
            }
        }

        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }
    }
}
