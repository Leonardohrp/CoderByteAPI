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
        public void GetUserById_Success()
        {
            // Arrange
            var user = new User()
            {
                IdUser = 1,
                Name = "Leonardo",
                Email = "leonardo@hotmail.com",
                DateOfBirth = DateTime.Now,
                Phone = "15991187263"
            };

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(m => m.GetUserById(user.IdUser).Result).Returns(user).Verifiable();

            var mockAddressService = new Mock<IAddressService>();

            IUserService userService = new UserService(mockUserRepository.Object, mockAddressService.Object);

            // Act
            var userExpected = userService.GetUserById(user.IdUser).Result;

            // Assert
            mockUserRepository.Verify();
            Assert.IsNotNull(userExpected);
            Assert.AreEqual(userExpected, user);
        }

        [Test]
        public void CreateUserWithAddress_Success()
        {
            // Arrange
            var createAddressList = new List<CreateAddress>
            {
                new CreateAddress
                {
                    ZipCode = "18020234",
                    Categoria = CategoryEnum.Residential
                }
            };

            var createUser = new CreateUser()
            {
                Name = "Leonardo",
                Email = "leonardo@hotmail.com",
                DateOfBirth = DateTime.Now,
                Phone = "15991187263",
                AddressInformations = createAddressList
            };

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(m => m.CreateUser(createUser).Result).Returns(1).Verifiable();

            var mockAddressService = new Mock<IAddressService>();
            mockAddressService.Setup(m => m.CreateAddressWithUserAssociation(createAddressList[0], 1)).Verifiable();

            IUserService userService = new UserService(mockUserRepository.Object, mockAddressService.Object);

            // Act
            var isUserCreated = userService.CreateUserWithAddress(createUser).Result;

            // Assert
            mockUserRepository.Verify();
            mockAddressService.Verify();
            Assert.IsNotNull(isUserCreated);
            Assert.AreEqual(isUserCreated, 1);
        }

        //GetListUsersByName
        //UpdateUserById
        //DeleteUserById
        //GetAddressListByUserId
    }
}