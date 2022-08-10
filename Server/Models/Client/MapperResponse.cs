using System.Text.Json.Serialization;

namespace Server.Models.Client
{
    public class MapperResponse
    {
        [JsonPropertyName("company_id")]
        public string? CompanyId { get; set; }

        [JsonPropertyName("initial_load_amount")]
        public decimal InitialLoadAmount { get; set; } = 0;

        public EMLRegistration? Registration { get; set; }
    }

    public class EMLRegistration
    {
        public string? Title { get; set; }

        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("middle_name")]
        public string? MiddleName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("email_address")]
        public string? Email { get; set; }

        [JsonPropertyName("mobile_number")]
        public string? Mobile { get; set; }

        [JsonPropertyName("primary_address")]
        public EMLAddress? PrimaryAddress { get; set; }
    }

    public class EMLAddress
    {
        [JsonPropertyName("address_line1")]
        public string? AddressLine1 { get; set; }

        [JsonPropertyName("address_line2")]
        public string? AddressLine2 { get; set; }

        [JsonPropertyName("address_line3")]
        public string? AddressLine3 { get; set; }

        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }
}
