using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Restaurant.Common.Handlers
{
    public class ApiData
    {
        public string Key { get; set; }

        public string Secret { get; set; }

        public string 
    }


    public class UserLogin
    {
        public string Token { get; set; }

        public string Secret { get; set; }
    }

    public struct RequestHandler
    {
        private readonly IRestClient client;

        public DataFormat DataFormat { get; set; }



        private readonly string accountID;

        private readonly string secretKey;


        public RequestHandler(IRestClient restClient)
        {
            client = restClient;
            DataFormat = DataFormat.Xml;
        }


        public RequestHandler(string accountID, string secretKey)
        {

            this.accountID = accountID;
            this.secretKey = secretKey;
        }



        public T Execute<T>(params Tuple<string, string>[] headers)
        {
            IRestRequest request = new RestRequest();
            request.RequestFormat = DataFormat;
            request.AddParameter("id",id,ParameterType.GetOrPost);

            client.ExecuteAsync<T>();
        }


    }
}
