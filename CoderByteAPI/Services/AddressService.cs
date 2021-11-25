using CoderByteAPI.Helpers;
using CoderByteAPI.Models;
using CoderByteAPI.Models.Enums;
using CoderByteAPI.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repo;

        public AddressService(IAddressRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateAddressWithUserAssociation(CreateAddress createAddress, int userId)
        {
            var viaCepResponse = await ViaCEPIntegration.GetCompleteAddress(createAddress.ZipCode);

            Address address = new Address
            {
                IdUser = userId,
                Cep = viaCepResponse.Cep,
                Logradouro = viaCepResponse.Logradouro,
                Complemento = viaCepResponse.Complemento,
                Bairro = viaCepResponse.Bairro,
                Localidade = viaCepResponse.Localidade,
                Uf = viaCepResponse.Uf,
                Ibge = viaCepResponse.Ibge,
                Gia = viaCepResponse.Gia,
                Ddd = viaCepResponse.Ddd,
                Siafi = viaCepResponse.Siafi,
                Categoria = createAddress.Categoria
            };

            var isAddressCreated = await _repo.CreateAddressWithUserAssociation(address);

            if (isAddressCreated != 1)
                throw new Exception("Erro ao criar endereço.");
        }

        public async Task DeleteAddressByUserIdAndZipCode(int idUser, string ziCode)
        {
            var isAddressDeleted = await _repo.DeleteAddressByIdAndZipCode(idUser, ziCode);

            if (isAddressDeleted != 1)
                throw new Exception("Exclusão de endereço falhou.");
        }

        public async Task<List<Address>> GetAddressListByUserId(int IdUser)
        {
            return await _repo.GetAddressListByUserId(IdUser);
        }
    }
}
