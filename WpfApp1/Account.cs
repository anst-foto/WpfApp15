using System.Text.Json;
using System.Text.Json.Serialization;

namespace WpfApp1;

public record Account
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("login")]
    public string Login { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }

    public static Account FromJson(string json) =>
        JsonSerializer.Deserialize<Account>(json) ?? throw new Exception("Failed to deserialize account");
    public static string ToJson(Account account) => JsonSerializer.Serialize(account);
}