using FDNS.Common.Configuration;
using FDNS.Infrastructure.NamecheapAPI.Constants;
using System.Text;

namespace FDNS.Infrastructure.NamecheapAPI
{
    public class Query 
    {
        private readonly Dictionary<string, string> _parameters = new();
        private readonly StringBuilder _request = new();

        public string Result 
        { 
            get
            {
                foreach (KeyValuePair<string, string> param in _parameters)
                    _request.Append($"&{param.Key}={param.Value}");
                
                _parameters.Clear();
                return _request.ToString();
            } 
        }

        public Query(string command, NamecheapGlobalParameters globalParams)
        {
            if (globalParams == null)
                throw new ArgumentNullException("globalParams");

            _request.Append(globalParams.ApiServiceUrl)
                .Append($"?{NamecheapApiParams.Globals.Command}=").Append(command)
                .Append($"&{NamecheapApiParams.Globals.ApiUser}=").Append(globalParams.ApiUser)
                .Append($"&{NamecheapApiParams.Globals.Username}=").Append(globalParams.Username)
                .Append($"&{NamecheapApiParams.Globals.ApiKey}=").Append(globalParams.ApiKey)
                .Append($"&{NamecheapApiParams.Globals.ClientIp}=").Append(globalParams.ClientIp);
        }

        internal Query AddParameter(string key, string value)
        {
            _parameters.Add(key, value);
            return this;
        }

        internal Query RemoveParameter(string key)
        {
            _parameters.Remove(key);
            return this;
        }
    }
}
