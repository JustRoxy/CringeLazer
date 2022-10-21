using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CringeLazer.Application.Database;
using CringeLazer.Core.Exceptions;
using CringeLazer.Core.Models;
using CringeLazer.Core.Services;
using CringeLazer.Core.Settings;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CringeLazer.Application.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly CringeContext _context;
    private readonly Settings _settings;

    public AuthorizationService(CringeContext context, IOptions<Settings> settings)
    {
        _context = context;
        _settings = settings.Value;
    }

    public async Task<Result<OAuthToken>> Access(string username, string password)
    {
        var user = await _context.Users.Select(x => new UserModel
        {
            Password = x.Password,
            Username = username,
            UserId = x.UserId,
        }).FirstOrDefaultAsync(x => x.Username == username);

        if (user is null)
            return new Result<OAuthToken>(new StatusCodeException("User not found", 404));

        if (!BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password))
            return new Result<OAuthToken>(new StatusCodeException("Incorrect username or password", 401));

        var tokens = GenerateToken(user.UserId);
        var session = new SessionModel
        {
            RefreshToken = tokens.RefreshToken,
            UserId = user.UserId
        };
        _context.Sessions.Add(session);

        await _context.SaveChangesAsync();

        return tokens;
    }

    public async Task<Result<OAuthToken>> Refresh(string token)
    {
        var session = await _context.Sessions.FirstOrDefaultAsync(x => x.RefreshToken == token);
        if (session is null)
            return new Result<OAuthToken>(new StatusCodeException("Session with this refresh-token is not found", 404));

        var tokens = GenerateToken(session.UserId);
        session.RefreshToken = tokens.RefreshToken;

        await _context.SaveChangesAsync();

        return tokens;
    }

    private OAuthToken GenerateToken(long userId)
    {
        var handler = new JwtSecurityTokenHandler();
        var now = DateTime.UtcNow;
        var expires = now.AddDays(5);
        var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.AuthorizationKey)),
            "HS256");
        var accessToken = handler.CreateEncodedJwt("CringeLazer", "osu", new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, userId.ToString()),
            new Claim(ClaimTypes.NameIdentifier, userId.ToString())
        }), now, expires, now, creds);

        var buffer = new byte[24];
        RandomNumberGenerator.Fill(buffer);
        var refreshToken = Convert.ToBase64String(buffer);

        return new OAuthToken
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresIn = (expires - now).TotalMilliseconds
        };
    }
}
