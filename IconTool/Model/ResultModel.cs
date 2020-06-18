using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconTool.Model
{
    public class ResultModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///  获取一个值，该值指示 HTTP 响应是否成功。true 如果System.Net.Http.HttpResponseMessage.StatusCode已在范围内 200-299; 否则为false。
        /// </summary>
        public bool IsSuccess { get { return Code >= 200 && Code < 300; } }
    }

    public class ResultModel<T>: ResultModel
    { 
        public T Data { get; set; }
    }
}
