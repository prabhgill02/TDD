using CloudCustomers.WebAPI.Models;

namespace CloudCustomers.UnitTests.Fixtures;

public static class UsersFixuture
{
    public static List<User> GetTestUsers() => new() {
        new User {
             Name = "Alpha test user 1",
             Email = "alpha@gmail.com",
             Address = new Address {
                Street = "124 alpha st.",
                City = "Somewhere",
                ZipCode = "154321"
             }
        },
        new User {
             Name = "Beta test user 2",
             Email = "Beta@gmail.com",
             Address = new Address {
                Street = "124 beta st.",
                City = "BetaSomewhere",
                ZipCode = "154322"
             }
        },
        new User {
             Name = "Gama test user 3",
             Email = "gama@gmail.com",
             Address = new Address {
                Street = "124 gama st.",
                City = "GamaSomewhere",
                ZipCode = "154323"
             }
        }

    };
}
