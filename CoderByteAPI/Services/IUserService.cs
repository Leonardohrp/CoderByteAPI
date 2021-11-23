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
        Task<bool> CreateUserWithAddress(CreateUser createUser);
        Task<bool> UpdateUserById(UpdateUser updateUser, int id);
        Task<bool> DeleteUserById(int id);
        Task<List<User>> GetListUsersByName(string name);

        Task<List<Address>> GetAddressListByUserId(int id);
    }
}
