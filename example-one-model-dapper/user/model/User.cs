using example_one_model_dapper.user.model.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_one_model_dapper.user.model
{
    public class User : IUserBuilder
    {
        
        private int id;
        private string username;
        private string email;
        private string password;

        #region CONSTRUCTORS

        public User(int id, string username, string email, string password)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.password = password;
        }

        public User()
        {
            this.id = -1;
            this.username = "unknown";
            this.email = "unknown";
            this.password = "";
        }

        #endregion

        #region ACCESSORS

        public int GetId() { return this.id; }
        public string GetUsername() { return this.username; }
        public string GetEmail() { return this.email; }
        public string GetPassword() { return this.password; }
        public void SetId(int id) { this.id = id; }
        public void SetUsername(string username) { this.username = username; }
        public void SetEmail(string email) { this.email = email; }
        public void SetPassword(string password) { this.password = password; }

        #endregion

        #region BUILDER

        public User Id(int id)
        {
            this.id = id;
            return this;
        }

        public User Username(string username)
        {
            this.username = username;
            return this;
        }

        public User Email(string email)
        {
            this.email = email;
            return this;
        }

        public User Password(string password)
        {
            this.password = password;
            return this;
        }

        #endregion

        #region METHODS

        public override string ToString()
        {
            string desc = "";
            desc += $"Id : {this.id}\n";
            desc += $"Username : {this.username}\n";
            desc += $"Email : {this.email}\n";
            return desc;
        }

        public override bool Equals(object? obj)
        {
            User user = obj as User;
            return user.id == this.id && user.username.Equals(this.username) && user.email.Equals(this.email) && user.password.Equals(this.password);
        }

        public override int GetHashCode()
        {
            return (int)Math.Pow(this.id, 2) + this.username.Length * 2 + this.email.Length;
        }

        #endregion
    }
}
