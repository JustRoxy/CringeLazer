using MediatR;

namespace CringeLazer.Bancho.Helpers;

public interface IResultRequest<T> : IRequest<Result<T>>
{

}
