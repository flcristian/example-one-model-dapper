using example_one_model_depper.user.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.user.service.interfaces
{
    public interface IUserQueryService
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        bool IsUser(User user);
    }
}
