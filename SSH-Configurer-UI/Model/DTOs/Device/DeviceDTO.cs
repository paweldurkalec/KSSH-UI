﻿using Foolproof;
using System.ComponentModel.DataAnnotations;
using SSH_Configurer_UI.Model;

namespace SSH_Configurer_UI.Model.DTOs.Device
{
    public class DeviceDTO
    {
        public int id { get; set; }

        public string name { get; set; }

        public string hostname { get; set; }

        public int port { get; set; } = 22;

        public string username { get; set; }

        public int? key_pair { get; set; }

        public string? password { get; set; }
        public DeviceDTO() { }

        public DeviceDTO(Model.Device device)
        {
            id = device.Id;
            name = device.Name;
            hostname = device.Hostname;
            port = device.Port;
            username = device.Username;
            key_pair = device.KeyPairId > 0 ? device.KeyPairId : null;
            password = device.Password != "" ? device.Password : null;
        }
    }
}