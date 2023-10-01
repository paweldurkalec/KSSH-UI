namespace SSH_Configurer_UI.Model.DTOs.KeyPair
{
    public class KeyPairDTO
    {
        public string name { get; set; }
        public string private_key_content { get; set; }

        public string public_key_content { get; set; }

        public KeyPairDTO() { }

        public KeyPairDTO(Model.KeyPair keyPair)
        {
            name = keyPair.Name;
            public_key_content = keyPair.PublicKey;
            private_key_content = keyPair.PrivateKey;
        }
    }
}
