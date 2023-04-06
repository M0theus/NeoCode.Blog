using NeoCode.Blog.API.ViewModel;

namespace NeoCode.Blog.API.Utilities;

public class Responses
{
    public static ResultViewModel ApplicartionErrorMensage()
    {
        return new ResultViewModel
        {
            Message = "Ocorreu algum error interno na aplicação, por favor tente novamente",
            Success = false,
            Data = null
        };
    }

    public static ResultViewModel DomainErrorMenssage(string message)
    {
        return new ResultViewModel
        {
            Message = message,
            Success = false,
            Data = null
        };
    }

    public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
    {
        return new ResultViewModel
        {
            Message = message,
            Success = false,
            Data = errors
        };
    }

    public static ResultViewModel UnauthorizedErrorMessage()
    {
        return new ResultViewModel
        {
            Message = "A combinação de login e senha está incorreta!",
            Success = false,
            Data = null
        };
    }
}