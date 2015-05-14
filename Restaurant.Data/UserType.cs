//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//
//namespace Restaurant.Data
//{
//    [Serializable]
//    public class UserType
//    {
//        public int UserTypeID { get; set; }
//
//        [Required]
//        public string Name { get; set; }
//
//        public virtual ICollection<User> Users { get; set; }
//
//        public UserType()
//        {
//            Name = String.Empty;
//        }
//
//        public override string ToString()
//        {
//            return String.Format("UserType: {0}", Name);
//        }
//    }
//}