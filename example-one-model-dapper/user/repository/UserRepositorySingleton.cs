using example_one_model_dapper.user.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.user.repository
{
    public class UserRepositorySingleton
    {
        private static readonly Lazy<UserRepository> _instance = new Lazy<UserRepository>(() => new UserRepository());

        public static UserRepository Instance => _instance.Value;

        private UserRepositorySingleton() { }
    }
}
