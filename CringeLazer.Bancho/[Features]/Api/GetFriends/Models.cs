using CringeLazer.Bancho.Contracts;
using MediatR;

namespace CringeLazer.Bancho._Features_.Api.Friends;

public class Request : RequestClaim, IRequest<List<User>>
{
}
