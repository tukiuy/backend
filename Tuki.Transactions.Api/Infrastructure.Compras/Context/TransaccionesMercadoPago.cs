using System;
using System.Collections.Generic;

namespace InfrastructureLayer.Compras.Context;

public partial class TransaccionesMercadoPago
{
    public int IdTransaccionMercadoPago { get; set; }

    public long? Id { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateApproved { get; set; }

    public DateTime? DateLastUpdated { get; set; }

    public DateTime? DateOfExpiration { get; set; }

    public DateTime? MoneyReleaseDate { get; set; }

    public string? OperationType { get; set; }

    public string? IssuerId { get; set; }

    public string? PaymentMethodId { get; set; }

    public string? PaymentTypeId { get; set; }

    public string? Status { get; set; }

    public string? StatusDetail { get; set; }

    public string? CurrencyId { get; set; }

    public string? Description { get; set; }

    public string? AuthorizationCode { get; set; }

    public long? CollectorId { get; set; }

    public int IdPagadorMercadoPago { get; set; }

    public decimal? TransactionAmount { get; set; }

    public decimal? TransactionAmountRefunded { get; set; }

    public int? Installments { get; set; }

    public int IdDetalleTransaccionMercadoPago { get; set; }

    public int? ApiResponsestatusCode { get; set; }

    public string? IpAddress { get; set; }

    public string? Payer { get; set; }

    public string? Shipments { get; set; }

    public long? OrderId { get; set; }

    public string? OrderType { get; set; }
}
