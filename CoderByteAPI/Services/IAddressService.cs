using CoderByteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Services
{
    public interface IAddressService
    {
        Task CreateAddressWithUserAssociation(CreateAddress createAddress, int IdUser);
        Task<List<Address>> GetAddressListByUserId(int IdUser);
        Task DeleteAddressByUserIdAndZipCode(int idUser, string ziCode);
    }
}
