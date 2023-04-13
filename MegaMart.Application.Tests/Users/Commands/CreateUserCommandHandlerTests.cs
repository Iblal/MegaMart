using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using MegaMart.Application.Users.Commands.CreateUser;
using MegaMart.Domain.Entities;
using MegaMart.Domain.Errors;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace MegaMart.Application.Tests.Users.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_ReturnFailureResult_WhenEmailIsNotUnique()
        {
            // Arrange
            var email = "test@example.com";
            var userName = "testuser";
            var password = "P@ssw0rd";
            var confirmPassword = "P@ssw0rd";

            var userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            userManagerMock.Setup(um => um.FindByEmailAsync(email))
                .ReturnsAsync(new User()); // Mock email already exists

            var passwordHasher = new PasswordHasher<User>();
            var handler = new CreateUserCommandHandler(userManagerMock.Object, passwordHasher);
            var command = new CreateUserCommand(email, userName, password, confirmPassword);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Succeeded.Should().BeFalse(); // Expect failure
            result.Errors.Should().Contain(error => error.Code == DomainErrors.UserErrors.EmailAlreadyRegistered.Code); // Expect email already registered error
        }

    }
}


