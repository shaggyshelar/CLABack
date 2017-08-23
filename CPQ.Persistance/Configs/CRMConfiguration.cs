using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Persistance.Configs
{
    public class CRMConfiguration
    {
        public string GetURL()
        {
            string url = "Url=" + ConfigurationManager.AppSettings["Url"].ToString();
            string userName = "Username=" + ConfigurationManager.AppSettings["Username"].ToString();
            string password = "Password=" + ConfigurationManager.AppSettings["Password"].ToString();
            return url + ";" + userName + ";" + password + ";"; ;
        }
    }
}
