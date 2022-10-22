using CringeLazer.Core.Models.Users;
using LanguageExt.Common;

namespace CringeLazer.Core.Services;

public interface IUserService
{
    public Task<Result<UserModel>> Create(string username, string email, string password);
    public Task<List<T>> GetMany<T>(Func<IQueryable<UserModel>, IQueryable<T>> map);
    public Task<T> GetOne<T>(Func<IQueryable<UserModel>, IQueryable<T>> map);
}
