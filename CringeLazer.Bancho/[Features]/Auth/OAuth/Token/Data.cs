using MongoDB.Entities;

namespace CringeLazer.Bancho._Features_.Auth.OAuth.Token;

public static class Data
{
    public static Task<Entities.User> GetUser(string username)
    {
        return DB.Find<Entities.User>()
            .Match(x => x.Username == username)
            .Project(x => new Entities.User
            {
                ID = x.ID,
                Password = x.Password,
                Username = x.Username
            })
            .ExecuteSingleAsync();
    }
}
