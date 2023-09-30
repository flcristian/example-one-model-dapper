using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.user.service.exceptions
{
    public class UserNotModified : Exception
    {
        public UserNotModified(string message) : base(message) { }
    }
}
