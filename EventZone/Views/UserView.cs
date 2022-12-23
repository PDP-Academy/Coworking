using EventZone.Models;
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

    public async ValueTask PrintSignUp()
    {
        Console.Write("Ismingizni kiriting: ");
        User user = new User();
        
        user.Name = Console.ReadLine();
        user.Role = Role.User;
        
        user = await this.userService.RegistrationUser(user);
        
        Console.WriteLine(user);
    }

    public async ValueTask PringOrder()
    {
        Order order = new Order();

        order = await this.userService.RegistrationOrders(order);
    }

    public async ValueTask PrintOrdersDay()
    {
        var temp = await this.userService.SelectAllOrdersAsync(DateTime.Now);
        Console.WriteLine(temp.Count);
    }
}
