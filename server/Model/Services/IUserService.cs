namespace Server.Model.Services
{
    public interface IUserService
    {
        bool IsValidUser(string userName, string password);
    }
}