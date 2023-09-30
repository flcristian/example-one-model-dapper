using example_one_model_dapper.user.repository;
using example_one_model_dapper.user.repository.interfaces;
using example_one_model_dapper.user.repository.testing;
using example_one_model_dapper.user.service.exceptions;
using example_one_model_dapper.user.service.interfaces;
using example_one_model_depper.user.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.user.service
{
    public class UserCommandService : IUserCommandService
    {
        private IUserRepository _repository;

        public UserCommandService()
        {
            _repository = UserRepositorySingleton.Instance;
        }

        public UserCommandService(String parameters)
        {
            _repository = TestUserRepositorySingleton.Instance;
        }

        public void AddUser(User user)
        {
            if (_repository.GetUserById(user.GetId()) != null) throw new IdAlreadyUsed("Id is already in use");
            if (_repository.GetUserByUsername(user.GetUsername()) != null) throw new UsernameAlreadyUsed("Username is already in use");
            if (_repository.GetUserByEmail(user.GetEmail()) != null) throw new EmailAlreadyUsed("Email is already used");
            _repository.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            if (_repository.GetUserById(id) == null) throw new UserDoesNotExist("User does not exist");
            _repository.DeleteUser(id);
        }

        public void UpdateUser(User user)
        {
            User check = _repository.GetUserById(user.GetId());
            if (check == null) throw new UserDoesNotExist("User does not exist");
            if (check.Equals(user)) throw new UserNotModified("User was not modified");
            _repository.UpdateUser(user);
        }
    }
}
