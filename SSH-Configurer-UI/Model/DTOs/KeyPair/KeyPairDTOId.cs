namespace SSH_Configurer_UI.Model.DTOs.KeyPair
{
    public class KeyPairDTOId
    {
        public int id { get; set; }
        public string name { get; set; }

        public string public_key_content { get; set; }

        public KeyPairDTOId() { }

        public KeyPairDTOId(Model.KeyPair keyPair)
        {
            id = keyPair.Id;
            name = keyPair.Name;
            public_key_content = keyPair.PublicKey;
        }
    }
}
