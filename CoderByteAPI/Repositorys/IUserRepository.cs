using CoderByteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Repositorys
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<int> CreateUser(CreateUser createUser);
        Task<int> UpdateUserById(UpdateUser updateUser, int id);
        Task<int> DeleteUserById(int id);
        Task<List<User>> GetListUsersByName(string name);
    }
}
