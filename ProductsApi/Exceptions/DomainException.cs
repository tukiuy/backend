namespace ProductsApi.Exceptions;

public class DomainException(string? message) : Exception(message) { }