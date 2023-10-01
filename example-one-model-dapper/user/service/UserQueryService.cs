using example_one_model_dapper.user.repository.interfaces;
using example_one_model_dapper.user.repository.testing;
using example_one_model_dapper.user.repository;
using example_one_model_dapper.user.service.interfaces;
using example_one_model_depper.user.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using example_one_model_dapper.user.service.exceptions;

namespace example_one_model_dapper.user.service
{
    public class UserQueryService : IUserQueryService
    {
        private IUserRepository _repository;

        public UserQueryService()
        {
            _repository = UserRepositorySingleton.Instance;
        }

        public UserQueryService(String parameters)
        {
            _repository = TestUserRepositorySingleton.Instance;
        }

        public List<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public int GetCount()
        {
            return _repository.GetCount();
        }

        public User GetUserByEmail(string email)
        {
            try { return _repository.GetUserByEmail(email); }
            catch(UserDoesNotExist ex) { throw ex; }
        }

        public User GetUserById(int id)
        {
            try { return _repository.GetUserById(id); }
            catch (UserDoesNotExist ex) { throw ex; }
        }

        public User GetUserByUsername(string username)
        {
            try { return _repository.GetUserByUsername(username); }
            catch (UserDoesNotExist ex) { throw ex; }
        }

        public bool IsUser(User user)
        {
            User check;
            try { check = _repository.GetUserById(user.GetId()); }
            catch(UserDoesNotExist ex) { return false; }
            if (check.Equals(user)) return true;
            return false;
        }
    }
}
