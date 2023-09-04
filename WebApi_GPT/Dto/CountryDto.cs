using Newtonsoft.Json;
namespace WebApi_GPT;

public class CountryDto
{
    [JsonProperty("name")]
    public NameDto name { get; set; }
    public int population { get; set; }
}

public class NameDto
{

    public string? common { get; set; }
    public string? official { get; set; }
    public Dictionary<string, NativeNameDto>? nativeName { get; set; }
}

public class NativeNameDto
{
    public string? official { get; set; }
    public string? common { get; set; }
}
