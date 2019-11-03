using System.ComponentModel.DataAnnotations;

namespace bitpctechapi.Contracts.V1.Requests
{
    public class UserRegistrationRequest
    {
        [EmailAddress] //This is used yo validated the input is a valide emaile address or not
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
