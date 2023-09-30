using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.user.service.testing
{
    public class TestUserQueryServiceSingleton
    {
        private static readonly Lazy<UserQueryService> _instance = new Lazy<UserQueryService>(() => new UserQueryService("TEST"));

        public static UserQueryService Instance => _instance.Value;

        private TestUserQueryServiceSingleton() { }
    }
}
