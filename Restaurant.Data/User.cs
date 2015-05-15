using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Restaurant.Data
{
    [Serializable]
    public class User
    {
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int ConnectionType { get; set; }

        public User()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            PhoneNumber = String.Empty;
            EmailAddress = String.Empty;
            Username = String.Empty;
            Password = String.Empty;
        }

        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        public void RemovePermision(int connectionType)
        {
            ConnectionType -= connectionType;
        }

        public void AddPermision(int connectionType)
        {
            ConnectionType += connectionType;
        }

        public override string ToString()
        {
            return String.Format("User: {0} {1}", FirstName, LastName);
        }
    }
}
