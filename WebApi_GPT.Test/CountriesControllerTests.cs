using Xunit;

namespace WebApi_GPT.Test
{
    public class CountriesControllerTests
    {
        private List<CountryDto> GetTestCountries()
        {
            return new List<CountryDto>
            {
                new CountryDto { name = new NameDto { common = "India", official = "Republic of India" }, population = 1393409038 },
                new CountryDto { name = new NameDto { common = "USA", official = "United States of America" }, population = 332915073 },
                new CountryDto { name = new NameDto { common = "China", official = "People's Republic of China" }, population = 1444216107 },
                new CountryDto { name = new NameDto { common = "Australia", official = "Commonwealth of Australia" }, population = 25649909 }
            };
        }

        [Fact]
        public void FilterCountriesByName_Test()
        {
            var countries = GetTestCountries();
            var filteredCountries = CountriesController.FilterCountriesByName(countries, "ind");

            Assert.Single(filteredCountries);
            Assert.Equal("India", filteredCountries[0].name.common);
        }

        [Fact]
        public void FilterCountriesByPopulation_Test()
        {
            var countries = GetTestCountries();
            var filteredCountries = CountriesController.FilterCountriesByPopulation(countries, 1000);

            Assert.Equal(2, filteredCountries.Count);
        }

        [Fact]
        public void SortCountriesByName_Test()
        {
            var countries = GetTestCountries();
            var sortedCountries = CountriesController.SortCountriesByName(countries, "descend");

            Assert.Equal("USA", sortedCountries[0].name.common);
            Assert.Equal("India", sortedCountries[1].name.common);
        }

        [Fact]
        public void LimitNumberOfRecords_Test()
        {
            var countries = GetTestCountries();
            var limitedCountries = CountriesController.LimitNumberOfRecords(countries, 2);

            Assert.Equal(2, limitedCountries.Count);
        }
    }
}