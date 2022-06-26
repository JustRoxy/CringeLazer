using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Auth.OAuth.Token;

public static class Data
{
    public static Task<Domain.User> GetUser(string username, CancellationToken token)
    {
        return DB.Find<Domain.User>()
            .Match(x => x.Username == username)
            .Project(x => new Domain.User
            {
                Id = x.Id,
                Password = x.Password,
                Username = x.Username
            })
            .ExecuteSingleAsync(token);
    }
}
