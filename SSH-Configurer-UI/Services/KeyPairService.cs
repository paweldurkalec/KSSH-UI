using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Pages.List;

namespace SSH_Configurer_UI.Services
{
    public class KeyPairService
    {
        private static readonly List<KeyPair> Keys = new()
        {
            new KeyPair(0, "my_key_1", "content_of_key_1", "content_of_key_1"),
            new KeyPair(1, "my_key_2", "content_of_key_2", "content_of_key_2")
        };

        public List<KeyPair> GetAllKeyPairs()
        {
            return Keys;
        }

        public KeyPair? GetById(int id)
        {
            return Keys.FirstOrDefault(keyPair => keyPair.Id == id, null);
        }

        public List<KeyPair> GetByIds(IEnumerable<int> ids) => ids.Select(GetById).Where(keyPair => keyPair is not null).ToList();

        public List<KeyPair> SearchByName(string input)
        {
            List<KeyPair> filtered = Keys.Where(keyPair => keyPair.Name.ToLower().Contains(input.ToLower())).ToList();

            return filtered;
        }

        public int AddKeyPair(KeyPair keyPair)
        {
            Keys.Add(keyPair);
            return 0;
        }

        public int UpdateKeyPair(int id, KeyPair keyPair)
        {
            int index = Keys.IndexOf(Keys.FirstOrDefault(keyPair => keyPair.Id == id));
            if (index != -1)
            {
                Keys[index] = keyPair;
                return 0;
            }
            return -1;
        }

        public int RemoveKeyPair(KeyPair keyPair)
        {
            Keys.Remove(keyPair);
            return 0;
        }
    }
}
