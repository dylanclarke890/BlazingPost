using BlazingPostMan.Data.Enums;

namespace BlazingPostMan.Data.Models
{
    public class AuthorisationData
    {
        public AuthorisationType AuthorisationType { get; set; }
        
        public string Key { get; set; }
        public string Value { get; set; }

        // for ApiKey auth
        public Section RelatedSection { get; set; }

        // Bearer Token
        public string BearerToken { get; set; }
    }
}
