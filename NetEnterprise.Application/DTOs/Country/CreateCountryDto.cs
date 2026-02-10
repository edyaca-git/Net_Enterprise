namespace NetEnterprise.Application.DTOs.Country;

public class CreateCountryDto
{
    public string CountryCode { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? UTCdiff { get; set; }
    public int? LanguageId { get; set; }
}