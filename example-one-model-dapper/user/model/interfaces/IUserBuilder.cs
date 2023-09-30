using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using example_one_model_depper.user.model;

namespace example_one_model_dapper.user.model.interfaces
{
    public interface IUserBuilder
    {
        User Id(int id);
        User Username(string username);
        User Email(string email);
        User Password(string password);

        public static User BuildUser() { return new User(); }
    }
}
