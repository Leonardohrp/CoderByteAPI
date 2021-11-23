using CoderByteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Repositorys
{
    public interface IAddressRepository
    {
        Task<int> CreateAddressWithUserAssociation(Address createAddress);
        Task<List<Address>> GetAddressListByUserId(int IdUser);
        Task<int> DeleteAddressById(int idUser, string ziCode);
    }
}
