using EventZone.Models;

namespace EventZone.Views;

internal interface IUserView
{
    ValueTask PrintUser();
    ValueTask PrintSignUp();

    ValueTask PringOrder();
    ValueTask PrintOrdersDay();
    ValueTask PrintSeatPlas();
}
