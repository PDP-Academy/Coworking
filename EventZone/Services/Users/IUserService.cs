using EventZone.Models;

namespace EventZone.Services.Users;

internal interface IUserService
{
    ValueTask<User> RetrieveUserByIdAsync(int userId); 
}