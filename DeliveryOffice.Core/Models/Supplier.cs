﻿using DeliveryOffice.Core.Abstractions.EntityRules;

namespace DeliveryOffice.Core.Models;

/// <summary>
///     Поставщик
/// </summary>
public class Supplier : IAuditable, ISoftDelete
{
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    ///     Наименование поставщика (компании)
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    ///     Адрес поставщика
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    ///     Список счетов поставщика
    /// </summary>
    public List<Bill> Bills { get; set; } = new();

    /// <inheritdoc />
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <inheritdoc />
    public DateTime? ModifiedAt { get; set; }

    /// <inheritdoc />
    public bool IsDeleted { get; set; }
}
