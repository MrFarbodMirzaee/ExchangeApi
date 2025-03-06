#nullable disable
namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents a file entity within the Exchange API system.
/// This entity stores information about files uploaded by users.
/// </summary>
public class File
{
    #region Properties

    /// <summary>
    /// A unique identifier for each file.
    /// </summary>
    public Guid Id { get; set; }

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

    #endregion
}