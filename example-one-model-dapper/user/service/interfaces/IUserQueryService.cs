using example_one_model_dapper.user.model;
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
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
        bool IsUser(User user);
        int GetCount();
    }
}
