using CoderByteAPI.Models;
using CoderByteAPI.Models.Enums;
using CoderByteAPI.Repositorys;
using CoderByteAPI.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace NUnitTest_API_CoderByte
{
    public class UserTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Test1()
        {
            // Arrange
            var addressList = new List<Address>()
            { 
                new Address()
                {
                    IdAddress = 1,
                    Cep = "18020234",
                    Logradouro = "",
                    Complemento = "Casa de esquina",
                    Bairro = "Bairro",
                    Localidade = "Localidade",
                    Uf = "SP",
                    Ibge = "1",
                    Gia = "2",
                    Ddd = "3",
                    Siafi = "4",
                    Categoria = CategoryEnum.Commercial
                }
            };

            var user = new User()
            {
                IdUser = 1,
                Name = "Leonardo",
                Email = "leonardo@hotmail.com",
                DateOfBirth = DateTime.Now,
                Phone = "15991187263",
                Address = addressList
            };

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(m => m.GetUserById(user.IdUser).Result).Returns(user).Verifiable();

            var mockAddressService = new Mock<IAddressService>();
            mockAddressService.Setup(m => m.GetAddressListByUserId(user.IdUser).Result).Returns(addressList);

            IUserService userService = new UserService(mockUserRepository.Object, mockAddressService.Object);

            // Act
            var userExpected = await userService.GetUserById(user.IdUser);

            // Assert
            mockUserRepository.Verify();
            mockAddressService.Verify();
            Assert.IsNotNull(userExpected);
            Assert.AreEqual(userExpected, user);
        }
    }
}