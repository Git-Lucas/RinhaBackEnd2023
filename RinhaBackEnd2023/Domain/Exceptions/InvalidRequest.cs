namespace RinhaBackEnd2023.Domain.Exceptions;

public class InvalidRequest(string messageError) : BaseException
{
    public string MessageError { get; private set; } = messageError;
}
