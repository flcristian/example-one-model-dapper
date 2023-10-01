using example_one_model_depper.user.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.user.repository.interfaces
{
    public interface IUserRepository
    {
        void Clear();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User GetUserById(int id);
        User GetUserByUsername(String username);
        User GetUserByEmail(String email);
        List<User> GetAllUsers();
        int GetCount();
    }
}
