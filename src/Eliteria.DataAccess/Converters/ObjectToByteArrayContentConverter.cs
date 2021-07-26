using Newtonsoft.Json;
using System.Net.Http;

namespace Eliteria.DataAccess.Converters
{
    public class ObjectToByteArrayContentConverter
    {
        public static ByteArrayContent Execute(object o)
        {
            var content = JsonConvert.SerializeObject(o);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}
