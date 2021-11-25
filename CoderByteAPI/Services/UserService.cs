using CoderByteAPI.Helpers;
using CoderByteAPI.Models;
using CoderByteAPI.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IAddressService _addressSerice;

        public UserService(IUserRepository repo, IAddressService addressService)
        {
            _repo = repo;
            _addressSerice = addressService;
        }

        public async Task<int> CreateUserWithAddress(CreateUser createUser)
        {
            UserFieldsValidator.ValidateCreateUserFields(createUser);

            int userId = await _repo.CreateUser(createUser);

            if (userId == 0) 
                throw new Exception("Criação de usuário falhou. Tente novamente");

            foreach (var address in createUser.AddressInformations)
            {
                await _addressSerice.CreateAddressWithUserAssociation(address, userId);
            }

            return userId;
        }

        public async Task DeleteUserById(int id)
        {
            var isUserDeleted = await _repo.DeleteUserById(id);
            if (isUserDeleted == 0)
                throw new Exception("Id não corresponde a nenhum usuário.");
        }

        public async Task<List<Address>> GetAddressListByUserId(int id)
        {
            var addressList = await _addressSerice.GetAddressListByUserId(id);
            if (addressList.Count == 0)
                throw new Exception("Usuário não possui endereços cadastrados");

            return addressList;
        }

        public async Task<List<User>> GetListUsersByName(string name)
        {
            var userList = await _repo.GetListUsersByName(name);
            if (userList.Count == 0)
                throw new Exception("Usuário não cadastrado.");
            
            return userList;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
                throw new Exception("Usuário não cadastrado.");

            return user;
        }

        public async Task<User> UpdateUserById(UpdateUser updateUser, int id)
        {
            var userUpdated = await _repo.UpdateUserById(updateUser, id);

            if (userUpdated == null)
                throw new Exception("Atualização do usuário falhou.");

            return userUpdated; 
        }
    }
}
