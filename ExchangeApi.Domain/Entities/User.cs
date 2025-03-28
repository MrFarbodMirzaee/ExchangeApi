﻿#nullable disable
using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents an individual user within the Exchange API system.
/// Implements interfaces for auditable and deletable entities.
/// </summary>
[Entity]
public class User : IBaseEntity<Guid>, IDeletable, IAuditable
{
    #region Properties

    /// <summary>
    /// A unique identifier for each user.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The full name of the user.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A unique username chosen by the user for login.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// The user's email address for communication and notifications.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// A hashed representation of the user's password for authentication.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// The timestamp indicating when the user account was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// A flag indicating whether the user's account is currently active.
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// The timestamp of the last update made to the user’s account.
    /// </summary>
    public DateTime Updated { get; set; }

    /// <summary>
    /// A brief description of the user.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// A meta description for SEO or informational purposes.
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// The identifier of the user who deleted this account, if applicable.
    /// </summary>
    public Guid DeletedByUserId { get; set; }

    /// <summary>
    /// The identifier of the user who last updated this account.
    /// </summary>
    public Guid UpdatedByUserId { get; set; }

    #endregion

    /// <summary>
    /// Activates the user's account.
    /// </summary>
    public void Activate() => IsActive = true;

    /// <summary>
    /// Deactivates the user's account.
    /// </summary>
    public void Deactivate() => IsActive = false;

    #region Navigations

    /// <summary>
    /// A collection of exchange transactions associated with the user.
    /// </summary>
    public ICollection<ExchangeTransaction> ExchangeTransactions { get; set; }

    #endregion
}