using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var json=JsonConvert.SerializeObject(Data,Formatting.None,jsonSerializerSetting);
            response.Write(json);
        }
    }
}
