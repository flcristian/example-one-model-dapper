using example_one_model_dapper.user.model.interfaces;
using example_one_model_dapper.user.repository.interfaces;
using example_one_model_dapper.user.repository.testing;
using example_one_model_dapper.user.service.exceptions;
using example_one_model_depper.user.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_example_one_model_dapper.service
{
    public class TestUserRepository
    {
        IUserRepository repository = TestUserRepositorySingleton.Instance;
        
        [Fact]
        public void TestAddUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("test")
                .Email("test")
                .Password("test");

            // Act
            int count = repository.GetCount();
            repository.AddUser(user);

            // Assert
            Assert.Equal(count + 1, repository.GetCount());
            Assert.Contains(user, repository.GetAllUsers());
            Assert.Equal(user, repository.GetUserById(user.GetId()));

            // Cleaning up
            repository.DeleteUser(user.GetId());
        }

        [Fact]
        public void TestDeleteUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("test")
                .Email("test")
                .Password("test");
            repository.AddUser(user);

            // Act
            int count = repository.GetCount();
            repository.DeleteUser(user.GetId());

            // Assert
            Assert.Equal(count - 1, repository.GetCount());
            Assert.DoesNotContain(user, repository.GetAllUsers());
        }

        [Fact]
        public void TestUpdateUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("test")
                .Email("test")
                .Password("test");
            User updated = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("updated")
                .Email("updated")
                .Password("updated");
            repository.AddUser(user);

            // Act
            repository.UpdateUser(updated);

            // Assert
            Assert.DoesNotContain(user, repository.GetAllUsers());
            Assert.Contains(updated, repository.GetAllUsers());
            Assert.Equal(updated, repository.GetUserById(user.GetId()));

            // Cleaning up
            repository.DeleteUser(user.GetId());
        }

        [Fact]
        public void TestGetUserById_UserDoesNotExist_ThrowsUserDoesNotExistException()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("test")
                .Email("test")
                .Password("test");

            // Assert
            Assert.Throws<UserDoesNotExist>(() => repository.GetUserById(user.GetId()));
        }

        [Fact]
        public void TestGetUserById_UserExists_ReturnsUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("test")
                .Email("test")
                .Password("test");
            repository.AddUser(user);

            // Act
            User check = repository.GetUserById(user.GetId());

            // Assert
            Assert.Equal(user, check);

            // Cleaning up
            repository.DeleteUser(user.GetId());
        }

        [Fact]
        public void TestGetUserByUsername_UserDoesNotExist_ThrowsUserDoesNotExistException()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("test")
                .Email("test")
                .Password("test");

            // Assert
            Assert.Throws<UserDoesNotExist>(() => repository.GetUserByUsername(user.GetUsername()));
        }

        [Fact]
        public void TestGetUserByUsername_UserExists_ReturnsUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("test")
                .Email("test")
                .Password("test");
            repository.AddUser(user);

            // Act
            User check = repository.GetUserByUsername(user.GetUsername());

            // Assert
            Assert.Equal(user, check);

            // Cleaning up
            repository.DeleteUser(user.GetId());
        }

        [Fact]
        public void TestGetUserByEmail_UserDoesNotExist_ThrowsUserDoesNotExistException()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("test")
                .Email("test")
                .Password("test");

            // Assert
            Assert.Throws<UserDoesNotExist>(() => repository.GetUserByEmail(user.GetEmail()));
        }

        [Fact]
        public void TestGetUserByEmail_UserExists_ReturnsUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("test")
                .Email("test")
                .Password("test");
            repository.AddUser(user);

            // Act
            User check = repository.GetUserByEmail(user.GetEmail());

            // Assert
            Assert.Equal(user, check);

            // Cleaning up
            repository.DeleteUser(user.GetId());
        }

        [Fact]
        public void TestGetAllUsers()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("test")
                .Email("test")
                .Password("test");
            repository.AddUser(user);

            // Act
            List<User> users = repository.GetAllUsers();

            // Assert
            Assert.Equal(new List<User> { user }, users);
            Assert.Single(users);

            // Cleaning up
            repository.DeleteUser(user.GetId());
        }

        [Fact]
        public void TestGetCount()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(1000)
                .Username("test")
                .Email("test")
                .Password("test");
            User another = IUserBuilder.BuildUser()
                .Id(999)
                .Username("another")
                .Email("another")
                .Password("another");
            repository.AddUser(user);
            repository.AddUser(another);

            // Act
            int count = repository.GetCount();

            // Assert
            Assert.Equal(2, count);

            // Cleaning up
            repository.DeleteUser(user.GetId());
            repository.DeleteUser(another.GetId());
        }
    }
}
