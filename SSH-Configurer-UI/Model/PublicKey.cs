namespace SSH_Configurer_UI.Model
{
    public class PublicKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public PublicKey(int id, string name, string content)
        {
            Id = id;
            Name = name;
            Content = content;
        }

        public PublicKey() { }
    }
}
