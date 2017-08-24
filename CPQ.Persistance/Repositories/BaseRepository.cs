using CPQ.Persistance.Helper;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Persistance.Repositories
{
    public class BaseRepository
    {
        private OrganizationService _orgService;

        public EntityCollection FetchExpression(string query)
        {
            using (_orgService = new OrganizationService(CRMHelper.GetConnection()))
            {
                var fetchExpression = new FetchExpression(query);
                return _orgService.RetrieveMultiple(fetchExpression);
            }
        }
    }
}
