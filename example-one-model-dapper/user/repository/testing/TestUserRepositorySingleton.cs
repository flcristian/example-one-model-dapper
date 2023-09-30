using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.user.repository.testing
{
    public class TestUserRepositorySingleton
    {
        private static readonly Lazy<UserRepository> _instance = new Lazy<UserRepository>(() => new UserRepository("TEST"));

        public static UserRepository Instance => _instance.Value;

        private TestUserRepositorySingleton() { }
    }
}
