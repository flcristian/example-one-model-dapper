/*using example_one_model_dapper.user.model.interfaces;
using example_one_model_dapper.user.repository.interfaces;
using example_one_model_dapper.user.repository.testing;
using example_one_model_dapper.user.service.interfaces;
using example_one_model_dapper.user.service.testing;
using example_one_model_dapper.user.service.exceptions;
using example_one_model_depper.user.model;

namespace test_example_one_model_dapper.service
{
    public class UserCommandService
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

            // Cleaning up
            repository.DeleteUser(4);
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
            repository.DeleteUser(4);
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
            repository.DeleteUser(user.GetId());
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
            repository.DeleteUser(4);
        }
    }
}*/