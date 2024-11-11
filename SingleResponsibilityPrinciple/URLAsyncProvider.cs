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
            Task<IEnumerable <string>> task = Task.Run(() => origProvider.GetTradeAsync());
            return task;
        }
        public IEnumerable<string> GetTradeData()
        {
            Task<IEnumerable<string>> Task = Task.Run(() => GetTradeAsync());
            Task.Wait();

            IEnumerable <string>tradelist = Task.Result;
            return tradelist;
        }
    }
}
