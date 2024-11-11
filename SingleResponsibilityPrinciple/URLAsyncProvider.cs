using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class URLAsyncProvider : ITradeDataProvider
    {
        public URLAsyncProvider (ITradeDataProvider origProvider)
        {
            this.origProvider = origProvider;
        }

        public Task <IEnumerable<string>> GetTradeAsync()
        {
            return origProvider.GetTradeAsync();
        }
        public Task<IEnumerable<string>> GetTradeDataAsync()
        {
            return GetTradeAsync();
        }  
    }
}
