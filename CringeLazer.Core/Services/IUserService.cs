using CringeLazer.Core.Models;
using LanguageExt.Common;

namespace CringeLazer.Core.Services;

public interface IUserService
{
    public Task<Result<UserModel>> Create(string username, string email, string password);
}
