using API_LES.Data;
using CoderByteAPI.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Repositorys
{
    public class AddressRepository : IAddressRepository
    {

        private readonly IDataContext _dataContext;
        public AddressRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CreateAddressWithUserAssociation(Address address)
        {
            var connectionString = _dataContext.GetConnection();

            int isUserCreated = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = @"INSERT INTO [Address] (   [IdUser],
                                                            [Cep],
                                                            [Logradouro],
                                                            [Complemento],
                                                            [Bairro],
                                                            [Localidade],
                                                            [Uf],
                                                            [Ibge],
                                                            [Gia],
                                                            [Ddd],
                                                            [Siafi],
                                                            [Categoria]
                                                        ) 
                                                VALUES 
                                                        (
                                                            @IdUser,
                                                            @Cep,
                                                            @Logradouro,
                                                            @Complemento,
                                                            @Bairro,
                                                            @Localidade,
                                                            @Uf,
                                                            @Ibge,
                                                            @Gia,
                                                            @Ddd,
                                                            @Siafi,
                                                            @Categoria
                                                        );
                                ";
                    isUserCreated = await connnection.ExecuteAsync(query,
                            new
                            {
                                IdUser = address.IdUser,
                                Cep = address.Cep,
                                Logradouro = address.Logradouro,
                                Complemento = address.Complemento,
                                Bairro = address.Bairro,
                                Localidade = address.Localidade,
                                Uf = address.Uf,
                                Ibge = address.Ibge,
                                Gia = address.Gia,
                                Ddd = address.Ddd,
                                Siafi = address.Siafi,
                                Categoria = address.Categoria
                            });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return isUserCreated;
            }
        }

        public async Task<int> DeleteAddressById(int idUser, string zipCode)
        {
            var connectionString = _dataContext.GetConnection();

            int isAddressDeleted = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "DELETE FROM Address WHERE IdUser = @Id and Cep = @ZipCode";
                    isAddressDeleted = await connnection.ExecuteAsync(query, new { Id = idUser, ZipCode = zipCode });
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return isAddressDeleted;
            }
        }

        public async Task<List<Address>> GetAddressListByUserId(int IdUser)
        {
            var connectionString = _dataContext.GetConnection();

            IEnumerable<Address> addressList;
            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "SELECT * FROM Address WHERE IdUser = @Id";
                    addressList = await connnection.QueryAsync<Address>(query, new { Id = IdUser });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return addressList.ToList();
            }
        }
    }
}
