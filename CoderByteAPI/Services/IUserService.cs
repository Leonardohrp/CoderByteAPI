using CoderByteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<int> CreateUserWithAddress(CreateUser createUser);
        Task<User> UpdateUserById(UpdateUser updateUser, int id);
        Task DeleteUserById(int id);
        Task<List<User>> GetListUsersByName(string name);
        Task<List<Address>> GetAddressListByUserId(int id);
    }
}
