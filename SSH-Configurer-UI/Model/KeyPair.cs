namespace SSH_Configurer_UI.Model
{
    public class KeyPair
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }

        public KeyPair(int id, string name, string pubKey, string privKey)
        {
            Id = id;
            Name = name;
            PublicKey = pubKey;
            PrivateKey = privKey;
        }

        public KeyPair() { }
    }
}
