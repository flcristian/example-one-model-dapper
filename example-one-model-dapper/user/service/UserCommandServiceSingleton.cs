using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.user.service
{
    public class UserCommandServiceSingleton
    {
        private static readonly Lazy<UserCommandService> _instance = new Lazy<UserCommandService>(() => new UserCommandService());

        public static UserCommandService Instance => _instance.Value;

        private UserCommandServiceSingleton() { }
    }
}
