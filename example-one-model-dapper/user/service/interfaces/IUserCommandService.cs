using example_one_model_dapper.user.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.user.service.interfaces
{
    public interface IUserCommandService
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
