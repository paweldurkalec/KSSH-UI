using SSH_Configurer_UI.Model;

namespace SSH_Configurer_UI.Services
{
    public class KeyPairService
    {
        private static readonly List<KeyPair> Keys = new()
        {
            new KeyPair(0, "my_key_1", "content_of_key_1", "content_of_key_1"),
            new KeyPair(1, "my_key_2", "content_of_key_2", "content_of_key_2")
        };

        public List<KeyPair> GetAllKeys()
        {
            return Keys;
        }
    }
}
