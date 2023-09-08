using Foolproof;
using SSH_Configurer_UI.Model.DTOs.Device;
using System.ComponentModel.DataAnnotations;

namespace SSH_Configurer_UI.Model
{
    //[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    //public class RequiredIfAttribute : ValidationAttribute
    //{
    //    private string _otherProperty;
    //    private object _otherPropertyValue;

    //    public RequiredIfAttribute(string otherProperty, object otherPropertyValue, string errorMessage)
    //    {
    //        _otherProperty = otherProperty;
    //        _otherPropertyValue = otherPropertyValue;
    //        ErrorMessage = errorMessage;
    //    }

    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherProperty);

    //        if (otherPropertyInfo == null)
    //        {
    //            return new ValidationResult($"Property {_otherProperty} not found");
    //        }

    //        var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);

    //        if (object.Equals(otherPropertyValue, _otherPropertyValue))
    //        {
    //            if (value == null || (value is string stringValue && string.IsNullOrWhiteSpace(stringValue)))
    //            {
    //                return new ValidationResult(ErrorMessage);
    //            }
    //        }

    //        return ValidationResult.Success;
    //    }
    //}
    public class Device
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Hostname { get; set; }
        [Range(0, 65535, ErrorMessage = "Port must be from range (0,65535)")]
        public int Port { get; set; } = 22;
        [Required]
        public string Username { get; set; }
        //[RequiredIf("Password", "", "ServerPubKeyId is required when Password is empty.")]
        public int KeyPairId { get; set; } = -1;
        //[RequiredIf("ServerPubKeyId", -1, "Password is required when ServerPubKeyId is -1.")]
        public string Password { get; set; } = "";
        public Device() { }
        public Device(int id, string name, string hostname, int port, string username, int keyPairId, string password)
        {
            Id = id;
            Name = name;
            Hostname = hostname;
            Port = port;
            Username = username;
            KeyPairId = keyPairId;
            Password = password;
        }

        public Device(DeviceDTO deviceDTO)
        {
            Id = deviceDTO.id;
            Name = deviceDTO.name;
            Hostname = deviceDTO.hostname;
            Port = deviceDTO.port;
            Username = deviceDTO.username;
            KeyPairId = deviceDTO.key_pair ?? -1;
            Password = deviceDTO.password ?? "";
        }
    }
}
