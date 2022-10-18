using Newtonsoft.Json;

namespace CringeLazer.Bancho.Contracts;

public class GenericErrorResponse
{
    [JsonProperty("error")]
    public string Error { get; set; }
}
