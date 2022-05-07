using financial_management.Global;
using financial_management.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace financial_management.Models
{
    internal class LivenessModel
    {
        public bool GetServerStatus()
        {
            bool live = false;

            try
            {
                using (var server = new HttpClient())
                {
                    server.BaseAddress = new Uri(Status.endpointURL);
                    var responseData = server.GetAsync("category/liveness");
                    responseData.Wait();

                    var result = responseData.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readData = result.Content.ReadAsAsync<TransactionResponse>();
                        readData.Wait();

                        var response = readData.Result;

                        live = response.Sucess;
                    }
                }
            }
            catch (Exception ex)
            {
                // categories = store.GetCategories(null);
            }


            return live;

        }
    }
}
