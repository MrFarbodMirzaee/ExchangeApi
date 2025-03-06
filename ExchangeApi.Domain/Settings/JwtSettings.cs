#nullable disable
namespace ExchangeApi.Domain.Settings;

/// <summary>
/// Represents the settings for JSON Web Token (JWT) authentication.
/// This class holds configuration values needed for generating and validating JWT tokens.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// The secret key used for signing the JWT.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// The issuer of the JWT, typically the name of the application or service.
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// The audience for which the JWT is intended, often the intended recipient.
    /// </summary>
    public string Audience { get; set; }

    /// <summary>
    /// The duration in minutes for which the JWT is valid.
    /// </summary>
    public double DurationInMinutes { get; set; }
}