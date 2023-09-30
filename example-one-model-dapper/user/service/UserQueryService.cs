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
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
