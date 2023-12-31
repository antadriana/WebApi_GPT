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
     string nameFilter = "",
     int populationFilterInMillions = 0,
     string sortOrder = "ascend",
     int limit = 50) // default limit set to 50
    {
        var client = _clientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("https://restcountries.com/v3.1/all");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var countries = JsonSerializer.Deserialize<List<CountryDto>>(jsonString);

            // Filter countries by name
            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                countries = FilterCountriesByName(countries, nameFilter);
            }

            // Filter countries by population
            if (populationFilterInMillions > 0)
            {
                countries = FilterCountriesByPopulation(countries, populationFilterInMillions);
            }

            // Sort countries by name
            if (!string.IsNullOrEmpty(sortOrder))
            {
                countries = SortCountriesByName(countries, sortOrder);
            }

            // Limit number of records
            if (limit > 0)
            {
                countries = LimitNumberOfRecords(countries, limit);
            }

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

    public static List<CountryDto> FilterCountriesByPopulation(List<CountryDto> countries, int filterByPopulationInMillions)
    {
        int filterByPopulation = filterByPopulationInMillions * 1000000; // Convert millions to actual population
        return countries.Where(c => c.population < filterByPopulation).ToList();
    }

    public static List<CountryDto> SortCountriesByName(List<CountryDto> countries, string sortOrder)
    {
        return sortOrder.ToLower() switch
        {
            "ascend" => countries.OrderBy(c => c.name?.common).ToList(),
            "descend" => countries.OrderByDescending(c => c.name?.common).ToList(),
            _ => throw new ArgumentException("Invalid sort order. Use 'ascend' or 'descend'.")
        };
    }

    public static List<CountryDto> LimitNumberOfRecords(List<CountryDto> countries, int limit)
    {
        return countries.Take(limit).ToList();
    }
}

