    using static SSH_Configurer_UI.Data.DataTypes;

namespace SSH_Configurer_UI.Services
{
    public class PublicKeyService
    {
        private static readonly PublicKey[] Keys = new[]
        {
            new PublicKey(0, "content_of_key_0"),
            new PublicKey(1, "content_of_key_1")

        };

        public List<PublicKey> GetAllKeys()
        {
            return new List<PublicKey>(Keys);
        }
    }
}
