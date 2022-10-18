using CringeLazer.Core.Models;

namespace CringeLazer.Core.Services;

public interface IAuthorizationService
{
    public Task<Result<OAuthToken>> Access(string username, string password);
    public Task<Result<OAuthToken>> Refresh(string token);
}
