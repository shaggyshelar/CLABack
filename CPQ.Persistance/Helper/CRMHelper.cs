using CPQ.Persistance.Configs;
using Microsoft.Xrm.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Persistance.Helper
{
    public static class CRMHelper
    {
        private static CRMConfiguration config = new CRMConfiguration();

        public static CrmConnection GetConnection()
        {
            return CrmConnection.Parse(config.GetURL());
        }
    }
}
