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

        public async Task<bool> CreateUserWithAddress(CreateUser createUser)
        {
            UserFieldsValidator.ValidateFields(createUser);

            var userId = await _repo.CreateUser(createUser);

            if (userId == 0)
                throw new Exception("Criação de usuário falhou. Tente novamente");

            foreach (var address in createUser.AddressInformations)
            {
                await _addressSerice.CreateAddressWithUserAssociation(address, userId);
            }

            return true;
        }

        public async Task<bool> DeleteUserById(int id)
        {
            await GetUserById(id);

            if (await _repo.DeleteUserById(id) != 1)
                throw new Exception("Exclusão de usuário falhou.");

            return true;
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

            foreach (var user in userList)
            {
                var addressList = await _addressSerice.GetAddressListByUserId(user.IdUser);
                if (addressList.Count == 0)
                    throw new Exception("Nenhum endereço foi cadastrado para esse usuário.");

                user.Address = addressList;
            }
            
            return userList;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
                throw new Exception("Usuário não cadastrado.");

            var addressList = await _addressSerice.GetAddressListByUserId(id);
            if(addressList.Count == 0)
                throw new Exception("Nenhum endereço foi cadastrado para esse usuário.");

            user.Address = addressList;

            return user;
        }

        public async Task<bool> UpdateUserById(UpdateUser updateUser, int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                throw new Exception("Id do usuário vazio ou nulo.");

            await GetUserById(id);

            var userUpdated = await _repo.UpdateUserById(updateUser, id);

            if (userUpdated == 0)
                throw new Exception("Atualização do usuário falhou.");

            return true;
        }
    }
}
