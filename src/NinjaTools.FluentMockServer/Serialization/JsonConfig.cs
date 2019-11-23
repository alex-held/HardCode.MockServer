using Newtonsoft.Json;
using NinjaTools.FluentMockServer.Serialization;

namespace NinjaTools.FluentMockServer.Utils
{
    /// <inheritdoc />
    public class JsonConfig : JsonSerializerSettings
    {
        public static readonly JsonConfig Instance = new JsonConfig();

        public JsonConfig()
        {
            var resolver = new ContractResolver();
            StringEscapeHandling = StringEscapeHandling.EscapeHtml;
            NullValueHandling = NullValueHandling.Ignore;
            Formatting = Formatting.Indented;
            ContractResolver = resolver;
        }
    }
}
    
