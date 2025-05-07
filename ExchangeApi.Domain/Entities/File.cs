#nullable disable
using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents a file entity within the Exchange API system.
/// This entity stores information about files uploaded by users.
/// </summary>
public class File : BaseEntity<Guid> , IAuditable 
{
    #region Properties

    /// <summary>
    /// The name of the file as it was uploaded by the user.
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// The MIME type of the file, indicating the format of the file's content.
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    /// The binary data of the file, stored as a byte array.
    /// </summary>
    public byte[] FileData { get; set; }

    public Guid UpdatedByUserId { get; set; }
    #endregion

    #region Navigations
    
    /// <summary>
    /// The identifier of the user associated with this file.
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// The user associated with this file.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// The identifier of the currency associated with this file.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// The currency associated with this file.
    /// </summary>
    public Currency Currency { get; set; }
    
    #endregion

}