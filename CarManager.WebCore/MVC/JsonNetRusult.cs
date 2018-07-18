using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace CarManager.WebCore.MVC
{
    public class JsonNetRusult:System.Web.Mvc.JsonResult
    {
        public override void ExecuteResult(System.Web.Mvc.ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("ControllerContext");
            }
            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            var jsonSerializerSetting = new JsonSerializerSettings();
            //时间格式化
            jsonSerializerSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSetting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            var json=JsonConvert.SerializeObject(Data,Formatting.None,jsonSerializerSetting);
            response.Write(json);
        }
    }
}
