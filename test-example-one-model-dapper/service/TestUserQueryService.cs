using example_one_model_dapper.user.model.interfaces;
using example_one_model_dapper.user.repository.interfaces;
using example_one_model_dapper.user.repository.testing;
using example_one_model_dapper.user.service.exceptions;
using example_one_model_dapper.user.service.interfaces;
using example_one_model_dapper.user.service.testing;
using example_one_model_depper.user.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_example_one_model_dapper.service
{
    public class TestUserQueryService
    {
        IUserRepository repository = TestUserRepositorySingleton.Instance;
        IUserQueryService service = TestUserQueryServiceSingleton.Instance;

        [Fact]
        public void TestGetAllUsers_ReturnsCorrectList()
        {
            // Arrange
            User user1 = IUserBuilder.BuildUser()
                .Id(4)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            User user2 = IUserBuilder.BuildUser()
                .Id(5)
                .Username("test")
                .Email("test")
                .Password("test");
            repository.AddUser(user1);
            repository.AddUser(user2);

            // Act
            List<User> users = service.GetAllUsers();

            // Assert
            Assert.Equal(users, repository.GetAllUsers());
            Assert.Equal(2, users.Count());

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestGetCount_ReturnsCorrectCount()
        {
            // Arrange
            User user1 = IUserBuilder.BuildUser()
                .Id(4)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            User user2 = IUserBuilder.BuildUser()
                .Id(5)
                .Username("test")
                .Email("test")
                .Password("test");
            repository.AddUser(user1);
            repository.AddUser(user2);

            // Act
            int count = service.GetCount();

            // Assert
            Assert.Equal(count, repository.GetCount());
            Assert.Equal(2, count);

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestGetUserById_UserDoesNotExist_ThrowsUserDoesNotExistException()
        {
            // Making sure there are no users
            repository.Clear();

            Assert.Throws<UserDoesNotExist>(() => service.GetUserById(1));
        }

        [Fact]
        public void TestGetUserById_UserExists_ReturnsCorrectUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            repository.AddUser(user);

            // Act
            User check = service.GetUserById(user.GetId());

            // Assert
            Assert.Equal(user, check);
            Assert.NotNull(check);

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestGetUserByUsername_UserDoesNotExist_ThrowsUserDoesNotExistException()
        {
            // Making sure there are no users
            repository.Clear();

            Assert.Throws<UserDoesNotExist>(() => service.GetUserByUsername("test"));
        }

        [Fact]
        public void TestGetUserByUsername_UserExists_ReturnsCorrectUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            repository.AddUser(user);

            // Act
            User check = service.GetUserByUsername(user.GetUsername());

            // Assert
            Assert.Equal(user, check);
            Assert.NotNull(check);

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestGetUserByEmail_UserDoesNotExist_ThrowsUserDoesNotExistException()
        {
            // Making sure there are no users
            repository.Clear();

            Assert.Throws<UserDoesNotExist>(() => service.GetUserByEmail("test"));
        }

        [Fact]
        public void TestGetUserByEmail_UserExists_ReturnsCorrectUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            repository.AddUser(user);

            // Act
            User check = service.GetUserByEmail(user.GetEmail());

            // Assert
            Assert.Equal(user, check);
            Assert.NotNull(check);

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestIsUser_NoUserWithIdExists_ReturnsFalse()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");

            // Act
            bool exists = service.IsUser(user);

            // Assert
            Assert.False(exists);
        }

        [Fact]
        public void TestIsUser_IdMatchIsNotIdentical_ReturnsFalse()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            User add = IUserBuilder.BuildUser()
                .Id(1)
                .Username("test")
                .Email("test")
                .Password("test");
            repository.AddUser(add);

            // Act
            bool exists = service.IsUser(user);

            // Assert
            Assert.False(exists);

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestIsUser_IdenticalIdMatchExists_ReturnsTrue()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            repository.AddUser(user);

            // Act
            bool exists = service.IsUser(user);

            // Assert
            Assert.True(exists);

            // Cleaning up
            repository.Clear();
        }
    }
}
