namespace RinhaBackEnd2023.Domain.Exceptions.Repository;

public class RepositoryException(RepositoryExceptionType repositoryExceptionType, string messageError) : BaseException
{
    public RepositoryExceptionType RepositoryExceptionType { get; set; } = repositoryExceptionType;
    public string MessageError { get; private set; } = messageError;
}
