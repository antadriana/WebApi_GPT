using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
namespace WebApi_GPT;


[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;

    public CountriesController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> GetCountries(
        string param1 = "",
        int param2 = 0,
        string param3 = "",
        string param4 = "")
    {
        var client = _clientFactory.CreateClient();

        HttpResponseMessage response = await client.GetAsync("https://restcountries.com/v3.1/all");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();

            var countries = JsonSerializer.Deserialize<List<CountryDto>>(jsonString);

            return Ok(countries);
        }
        else
        {
            return StatusCode((int)response.StatusCode, "Error fetching countries");
        }
    }

    public static List<CountryDto> FilterCountriesByName(List<CountryDto> countries, string filter)
    {
        return countries.Where(c =>
            (c.name?.common != null && c.name.common.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0) ||
            (c.name?.official != null && c.name.official.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0) ||
            (c.name?.nativeName != null && c.name.nativeName.Values.Any(n =>
                (n.official != null && n.official.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (n.common != null && n.common.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
            ))
        ).ToList();
    }
}
