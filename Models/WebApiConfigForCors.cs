using System.Web.Http;
using System.Web.Http.Cors;

namespace back_end.Models
{
    public class WebApiConfigForCors
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            // or new EnableCorsAttribute("www.example.com", "*", "*");
            config.EnableCors(cors);
            
        }
    }
}
