﻿using SSH_Configurer_UI.Model.DTOs.KeyPair;
using System.ComponentModel.DataAnnotations;

namespace SSH_Configurer_UI.Model
{
    public class KeyPair
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PublicKey { get; set; }

        [Required]
        public string PrivateKey { get; set; }

        public KeyPair(int id, string name, string pubKey, string privKey)
        {
            Id = id;
            Name = name;
            PublicKey = pubKey;
            PrivateKey = privKey;
        }

        public KeyPair() { }

        public KeyPair(KeyPairDTOId keyPair) 
        {
            Id = keyPair.id;
            Name = keyPair.name;
            PublicKey = keyPair.public_key_content;
            PrivateKey = "";
        }
    }
}
