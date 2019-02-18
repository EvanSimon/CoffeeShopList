using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NewCoffeeShop.Models
{
    public class User
    {
        [Required]  
        [RegularExpression(@"^[a-zA-Z]{2,}$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{2,}$")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[A-z0-9]{5,30}@[a-z]{5,10}.[a-z]{2,3}$")]
        public string Email { set; get; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9]{5,}$")]
        public string Password { set; get; }

        [Required]
        [RegularExpression(@"^\d{10}")]
        public string PhoneNumber { set; get; }

        //[Required]
        //[RegularExpression(@"^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$")]
        //public string Birthday { set; get; }

        public User(string firstName, string lastName, string email, string phoneNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }


        public User() { }
    }
}