using example_one_model_dapper.user.model.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_depper.user.model
{
    public class User : IUserBuilder
    {
        private int _id;
        private string _username;
        private string _email;
        private string _password;

        #region CONSTRUCTORS

        public User(int id, string username, string email, string password)
        {
            _id = id;
            _username = username;
            _email = email;
            _password = password;
        }

        public User()
        {
            _id = -1;
            _username = "unknown";
            _email = "unknown";
            _password = "";
        }

        #endregion

        #region ACCESSORS

        public int GetId() { return _id; }
        public string GetUsername() { return _username; }
        public string GetEmail() { return _email; }
        public string GetPassword() { return _password; }
        public void SetId(int id) { _id = id; }
        public void SetUsername(string username) { _username = username; }
        public void SetEmail(string email) { _email = email; }
        public void SetPassword(string password) { _password = password; }

        #endregion

        #region BUILDER

        public User Id(int id)
        {
            _id = id;
            return this;
        }

        public User Username(string username)
        {
            _username = username;
            return this;
        }

        public User Email(string email)
        {
            _email = email;
            return this;
        }

        public User Password(string password)
        {
            _password = password;
            return this;
        }

        #endregion

        #region METHODS

        public override string ToString()
        {
            string desc = "";
            desc += $"Id : {_id}\n";
            desc += $"Username : {_username}\n";
            desc += $"Email : {_email}\n";
            return desc;
        }

        public override bool Equals(object? obj)
        {
            User user = obj as User;
            return user._id == _id && user._username.Equals(_username) && user._email.Equals(_email) && user._password.Equals(_password);
        }

        public override int GetHashCode()
        {
            return (int)Math.Pow(_id, 2) + _username.Length * 2 + _email.Length;
        }

        #endregion
    }
}
