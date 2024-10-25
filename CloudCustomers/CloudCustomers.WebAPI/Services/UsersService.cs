using System;
using CloudCustomers.WebAPI.Models;

public interface IUsersService {
    public Task<List<User>> GetAllUsers();
}

public class UsersService : IUsersService {
    public Task<List<User>> GetAllUsers() {
        throw new NotImplementedException();

    }
}

