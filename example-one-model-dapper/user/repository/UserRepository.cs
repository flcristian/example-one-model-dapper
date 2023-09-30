﻿using example_one_model_dapper.data;
using example_one_model_dapper.user.repository.interfaces;
using example_one_model_depper.user.model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.user.repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        private string _connectionString;
        private DataAccess _dataAccess;

        //Constructors

        public UserRepository()
        {
            _dataAccess = new DataAccess();
            _connectionString = GetConnection();

            _users = new List<User>();
            Load();
        }

        public UserRepository(String parameters)
        {
            _dataAccess = new DataAccess();
            _connectionString = GetTestConnection();

            _users = new List<User>();
            Load();
        }

        //Methods

        public void Load()
        {
            List<User> list = GetAllUsers();

            foreach (User user in list)
            {
                _users.Add(user);
            }
        }
        public void AddUser(User user)
        {
            string sql = "insert into user(_id,_username,_email,_password) values(@id,@username,@email,@password)";

            _dataAccess.SaveData(sql, new { id = user.GetId(), username = user.GetUsername(), email = user.GetEmail(), password = user.GetPassword() }, _connectionString);
        }
        public void DeleteUser(int id)
        {
            string sql = "delete from user where _id=@id";

            _dataAccess.SaveData(sql, new { id }, _connectionString);
        }
        public List<User> GetAllUsers()
        {
            string sql = "select * from user";

            return _dataAccess.LoadData<User, dynamic>(sql, new { }, _connectionString);
        }
        public User GetUserById(int id)
        {
            string sql = "select * from user where _id=@id";

            return _dataAccess.LoadData<User, dynamic>(sql, new { id }, _connectionString)[0];
        }
        public User GetUserByUsername(String username)
        {
            string sql = "select * from user where _username=@username";

            return _dataAccess.LoadData<User, dynamic>(sql, new { username }, _connectionString)[0];
        }
        public User GetUserByEmail(String email)
        {
            string sql = "select * from user where _email=@email";

            return _dataAccess.LoadData<User, dynamic>(sql, new { email }, _connectionString)[0];
        }
        public void UpdateUser(User user)
        {
            string sql = "update user set _username=@username,_email=@email,_password=@password where _id=@id";

            _dataAccess.SaveData(sql, new { id = user.GetId(), username = user.GetUsername(), email = user.GetEmail(), password = user.GetPassword() }, _connectionString);
        }

        public int GetCount()
        {
            string sql = "select count(_id) from user;";

            return _dataAccess.LoadData<int, dynamic>(sql, new { }, _connectionString)[0];
        }

        // Database Connection

        private string GetConnection()
        {
            string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            string connectionStringIs = configuration.GetConnectionString("Default")!;
            return connectionStringIs;
        }

        private string GetTestConnection()
        {
            string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("testappsettings.json").Build();
            string connectionStringIs = configuration.GetConnectionString("Default")!;
            return connectionStringIs;
        }
    }
}
