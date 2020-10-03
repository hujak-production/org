using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using server.Model.Data;
using System.Linq;

namespace server.Model.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _hasher;

        public UserService(ILogger<UserService> logger, ApplicationDbContext context, IPasswordHasher<User> hasher)
        {
            _logger = logger;
            _context = context;
            _hasher = hasher;
        }

        public bool IsValidUser(string userName, string password)
        {
            _logger.LogInformation("Validating user: {0}", userName);

            if (string.IsNullOrEmpty(password) || 
                string.IsNullOrEmpty(password))
            {
                return false;
            }

            var user = _context.Users.Single(x => x.UserName == userName);
            if (user is null)
            {
                _logger.LogInformation("User with name: {0} does not exist", userName);
                return false;
            }

            _logger.LogInformation("User with name: {0} exists", userName);

            var verificationResult = _hasher.VerifyHashedPassword(null, user.PasswordHash, password);

            _logger.LogInformation("Password verification result: {0}", verificationResult.ToString());

            return verificationResult == PasswordVerificationResult.Success;
        }
    }
}
