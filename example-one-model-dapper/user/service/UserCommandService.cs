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
            User id = null!, username = null!, email = null!;
            try { id = _repository.GetUserById(user.GetId()); }
            catch(UserDoesNotExist ex) { }

            try { username = _repository.GetUserByUsername(user.GetUsername()); }
            catch(UserDoesNotExist ex) { }

            try { email = _repository.GetUserByEmail(user.GetEmail()); }
            catch (UserDoesNotExist ex) { }

            if (id != null) throw new IdAlreadyUsed("Id is already in use");
            if (username != null) throw new UsernameAlreadyUsed("Username is already in use");
            if (email != null) throw new EmailAlreadyUsed("Email is already used");
            _repository.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            try { _repository.GetUserById(id); }
            catch (UserDoesNotExist ex) { throw ex; }
            _repository.DeleteUser(id);
        }

        public void UpdateUser(User user)
        {
            User check = null!;
            try { check = _repository.GetUserById(user.GetId()); }
            catch(UserDoesNotExist ex) { throw ex; }

            if (check.Equals(user)) throw new UserNotModified("User was not modified");
            _repository.UpdateUser(user);
        }
    }
}
