using SSH_Configurer_UI.Model;

namespace SSH_Configurer_UI.Services
{
    public class PublicKeyService
    {
        private static readonly List<PublicKey> Keys = new()
        {
            new PublicKey(0, "my_key_1", "content_of_key_0"),
            new PublicKey(1, "my_key_2", "content_of_key_1")

        };

        public List<PublicKey> GetAllKeys()
        {
            return Keys;
        }
    }
}
