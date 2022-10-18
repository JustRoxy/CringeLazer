using Newtonsoft.Json;

namespace CringeLazer.Bancho.Contracts.Responses;

public class RegistrationErrorResponse
{
    [JsonProperty("form_error")]
    public RegistrationErrors FormErrors { get; set; }
}

public class RegistrationErrors
{
    [JsonProperty("username")]
    public string[] Username { get; set; }

    [JsonProperty("user_email")]
    public string[] Email { get; set; }

    [JsonProperty("password")]
    public string[] Password { get; set; }
}
