using System.Text;

namespace SSH_Configurer_UI.Services
{
    public class MyUtils
    {
        public static ByteArrayContent ConvertToBytes(string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}
