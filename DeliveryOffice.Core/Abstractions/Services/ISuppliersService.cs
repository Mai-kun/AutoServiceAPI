﻿using DeliveryOffice.Core.Models;
using DeliveryOffice.Core.RequestModels;

namespace DeliveryOffice.Core.Abstractions.Services;

/// <summary>
///     Предоставляет функционал для работы с поставщиками
/// </summary>
public interface ISuppliersService
{
    /// <summary>
    ///     Возвращает список всех поставщиков
    /// </summary>
    Task<List<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Возвращает поставщика по его ID
    /// </summary>
    Task<Supplier> GetSupplierByIdAsync(Guid supplierId, CancellationToken cancellationToken);

    /// <summary>
    ///     Добавляет нового поставщика
    /// </summary>
    Task AddSupplierAsync(CreateSupplierRequest supplierModel);

    /// <summary>
    ///     Обновляет существующего поставщика
    /// </summary>
    Task UpdateSupplierAsync(SupplierRequest supplierRequest, CancellationToken cancellationToken);

    /// <summary>
    ///     Удаляет поставщика
    /// </summary>
    Task DeleteSupplierAsync(Guid id);
}
