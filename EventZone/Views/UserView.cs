using System.Threading.Channels;
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
        var temp = await this.userService.SelectAllOrdersAsync(DateTime.Now);
        var temp2 = await this.userService.GetSeatAllAsync();
        for (int i = 0; i < temp2.Count; i++)
        {
            Console.WriteLine(i + 1 + " " + temp2[i]);
        }
        Console.WriteLine("joyni tanlang");
        int pothition = int.Parse(Console.ReadLine()) - 1;
        order.SeatId = temp2[pothition].Id;
        for (int i = 0; i < temp.Count; i++)
        {
            Console.WriteLine(temp[i]);
        }

        order.UserId = 1;
        
        
        order = await this.userService.RegistrationOrders(order);

        Console.WriteLine(order);
    }

    public async ValueTask PrintOrdersDay()
    {
        var temp = await this.userService.SelectAllOrdersAsync(DateTime.Now);
        Console.WriteLine(temp.Count);
    }

    public async ValueTask PrintSeatPlas()
    {
        Seat seat = new Seat();
        Console.WriteLine("O'rindiq joyini kiriting");
        seat.Position = int.Parse(Console.ReadLine());
        var temp = await this.userService.RegistrationSeatAsync(seat);

        Console.WriteLine(seat);
    }
}
