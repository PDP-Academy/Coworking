using EventZone.Services.Users;

namespace EventZone.Views;

internal class UserView : IUserView
{
    private readonly IUserService userService;

    public UserView(IUserService userService)
    {
        this.userService = userService;
    }

    public async ValueTask PrintUser()
    {
        Console.Write("Enter the user id: ");
        int userId = int.Parse(Console.ReadLine());

        var user = await this.userService.RetrieveUserByIdAsync(userId);

        Console.WriteLine(user);
    }
}
