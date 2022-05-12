using System;
using System.Threading.Tasks;
using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using Repository;
using Repository.Interfaces;
using Service.DTOs.User;
using Xunit;

namespace Service.UnitTests
{
    public class AccountsServiceTests
    {
        private readonly AccountsService _sut;
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<SignInManager<User>> _signInManagerMock;

        public AccountsServiceTests()
        {
            _userManagerMock = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null,
                null, null, null);
            _signInManagerMock = new Mock<SignInManager<User>>(_userManagerMock.Object,
                Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<User>>(), null, null, null, null);
            
            _sut = new AccountsService(_userManagerMock.Object, _signInManagerMock.Object);
        }

        [Theory]
        [InlineData("user_id_1")]
        public async Task FindUserById_WhenAuthorIsFound_ReturnsUser(string id)
        {
            // Arrange
            var createdUser = new User
            {
                Id = "user_id_1",
                FullName = "Chowdhury"
            };

            _userManagerMock.Setup(um => um.FindByIdAsync(id)).ReturnsAsync(createdUser);

            // Act
            var foundUser = await _sut.FindUserById(id);

            // Assert
            Assert.Equal(createdUser, foundUser);
        }
        
        [Theory]
        [InlineData("user_id_1")]
        public async Task FindUserById_WhenAuthorIsNotFound_ReturnsNull(string id)
        {
            // Arrange
            var createdUser = new User
            {
                Id = "user_id_2",
                FullName = "Chowdhury"
            };

            _userManagerMock.Setup(um => um.FindByIdAsync(id)).ReturnsAsync((User) null);

            // Act
            var foundUser = await _sut.FindUserById(id);

            // Assert
            Assert.Null(foundUser);
        }
    }
}