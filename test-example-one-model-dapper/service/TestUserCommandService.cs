using example_one_model_dapper.user.model.interfaces;
using example_one_model_dapper.user.repository.interfaces;
using example_one_model_dapper.user.repository.testing;
using example_one_model_dapper.user.service.interfaces;
using example_one_model_dapper.user.service.testing;
using example_one_model_dapper.user.service.exceptions;
using example_one_model_depper.user.model;

namespace test_example_one_model_dapper.service
{
    public class TestUserCommandService
    {
        IUserRepository repository = TestUserRepositorySingleton.Instance;
        IUserCommandService service = TestUserCommandServiceSingleton.Instance;

        [Fact]
        public void TestAddUser_IdAlreadyUsed_ThrowsIdAlreadyUsedException_DoesNotAddUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(4)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            User add = IUserBuilder.BuildUser()
                .Id(4)
                .Username("test")
                .Email("test")
                .Password("test");
            repository.AddUser(user);

            // Assert
            Assert.Throws<IdAlreadyUsed>(() => service.AddUser(add));
            Assert.Single(repository.GetAllUsers());

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestAddUser_UsernameAlreadyUsed_ThrowsUsernameAlreadyUsedException_DoesNotAddUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(4)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            User add = IUserBuilder.BuildUser()
                .Id(5)
                .Username("radu")
                .Email("test")
                .Password("test");
            repository.AddUser(user);

            // Assert
            Assert.Throws<UsernameAlreadyUsed>(() => service.AddUser(add));

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestAddUser_EmailAlreadyUsed_ThrowsEmailAlreadyUsedException_DoesNotAddUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(4)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            User add = IUserBuilder.BuildUser()
                .Id(5)
                .Username("test")
                .Email("radu@email.com")
                .Password("test");
            repository.AddUser(user);

            // Assert
            Assert.Throws<EmailAlreadyUsed>(() => service.AddUser(add));

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestAddUser_NoExceptions_AddsUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(4)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");

            // Assert
            int count = repository.GetAllUsers().Count();
            service.AddUser(user);
            Assert.Equal(count + 1, repository.GetAllUsers().Count());

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestDeleteUser_UserDoesNotExist_ThrowsUserDoesNotExistException_DoesNotDeleteAnyUsers()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(4)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            User delete = IUserBuilder.BuildUser()
                .Id(5)
                .Username("test")
                .Email("test")
                .Password("test");
            repository.AddUser(user);

            // Assert
            Assert.Throws<UserDoesNotExist>(() => service.DeleteUser(delete.GetId()));
            Assert.Single(repository.GetAllUsers());

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestDeleteUser_UserExists_DeletesUser()
        {

            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(4)
                .Username("radu")
                .Email("radu@email.com")
                .Password("radu");
            repository.AddUser(user);

            // Assert
            repository.DeleteUser(user.GetId());
            Assert.Empty(repository.GetAllUsers());

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestUpdateUser_UserDoesNotExist_ThrowsUserDoesNotExistException_DoesNotUpdateAnyUsers()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(4)
                .Username("test")
                .Email("test")
                .Password("test");
            User update = IUserBuilder.BuildUser()
                .Id(4)
                .Username("test")
                .Email("test")
                .Password("test");

            // Assert
            Assert.Throws<UserDoesNotExist>(() => service.UpdateUser(user));

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestUpdateUser_UserNotModified_ThrowsUserNotModifiedException_DoesNotUpdateUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(4)
                .Username("test")
                .Email("test")
                .Password("test");
            User updated = IUserBuilder.BuildUser()
                .Id(4)
                .Username("test")
                .Email("test")
                .Password("test");
            repository.AddUser(user);

            // Assert
            Assert.Throws<UserNotModified>(() => service.UpdateUser(updated));
            Assert.Equal(user, repository.GetUserById(user.GetId()));

            // Cleaning up
            repository.Clear();
        }

        [Fact]
        public void TestUpdateUser_UserModifiedAndExists_ModifiesUser()
        {
            // Arrange
            User user = IUserBuilder.BuildUser()
                .Id(4)
                .Username("test")
                .Email("test")
                .Password("test");
            User updated = IUserBuilder.BuildUser()
                .Id(4)
                .Username("updated")
                .Email("updated")
                .Password("updated");
            repository.AddUser(user);

            // Assert
            service.UpdateUser(updated);
            Assert.Equal(updated, repository.GetUserById(user.GetId()));

            // Cleaning up
            repository.Clear();
        }
    }
}