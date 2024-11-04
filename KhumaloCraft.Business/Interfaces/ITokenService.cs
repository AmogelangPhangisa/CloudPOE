namespace KhumaloCraft.Business.Interfaces;

public interface ITokenService
{
  string GenerateToken(string userId, string email, string firstName, string lastName, IList<string> roles);
}
