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
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _dataContext;
        public UserRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CreateUser(CreateUser createUser)
        {
            var connectionString = _dataContext.GetConnection();

            int isUserCreated = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = @"INSERT INTO Users (   [Name],
                                                        [Email],
                                                        [DateOfBirth],
                                                        [Phone]
                                                    ) 
                                             VALUES (
                                                        @Name,
                                                        @Email,
                                                        @DateOfBirth,
                                                        @Phone
                                                    );
                                SELECT SCOPE_IDENTITY() as int";
                    isUserCreated = await connnection.QuerySingleAsync<int>(query,
                            new
                            {
                                Name = createUser.Name,
                                Email = createUser.Email,
                                DateOfBirth = createUser.DateOfBirth,
                                Phone = createUser.Phone
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

        public async Task<int> DeleteUserById(int id)
        {
            var connectionString = _dataContext.GetConnection();

            int isUserDeleted = 0;

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "DELETE FROM Users WHERE IdUser = @Id";
                    isUserDeleted = await connnection.ExecuteAsync(query, new { Id = id });
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("FK_Address_Users"))
                        throw new Exception("Endereços cadastrados para o usuário. Todos os endereços devem ser excluídos antes do usuário.");

                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return isUserDeleted;
            }
        }

        public async Task<List<User>> GetListUsersByName(string name)
        {
            var connectionString = _dataContext.GetConnection();

            IEnumerable<User> usersList;
            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "SELECT * FROM Users WHERE Name = @Name";
                    usersList = await connnection.QueryAsync<User>(query, new { Name = name });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return usersList.ToList();
            }
        }

        public async Task<User> GetUserById(int id)
        {
            var connectionString = _dataContext.GetConnection();

            User user = new User();
            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = "SELECT * FROM Users WHERE IdUser = @Id";
                    user = await connnection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connnection.Close();
                }
                return user;
            }
        }

        public async Task<int> UpdateUserById(UpdateUser updateUser, int id)
        {
            var connectionString = _dataContext.GetConnection();

            int isUserUpdated = 0;

            User user = await GetUserById(id);

            using (var connnection = new SqlConnection(connectionString))
            {
                try
                {
                    connnection.Open();
                    var query = @"UPDATE Users SET  
                                            [Name] = @Name,
                                            [Email] = @Email,
                                            [DateOfBirth] = @DateOfBirth,
                                            [Phone] = @Phone
                                                WHERE IdUser = @Id";
                    isUserUpdated = await connnection.ExecuteAsync(query,
                            new
                            {
                                Name = string.IsNullOrEmpty(updateUser.Name) ? user.Name : updateUser.Name,
                                Email = string.IsNullOrEmpty(updateUser.Email) ? user.Email : updateUser.Email,
                                DateOfBirth = string.IsNullOrEmpty(updateUser.DateOfBirth.ToString()) ? user.DateOfBirth : updateUser.DateOfBirth,
                                Phone = string.IsNullOrEmpty(updateUser.Phone) ? user.Phone : updateUser.Phone,
                                Id = id
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
                return isUserUpdated;
            }
        }
    }
}
