using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Minesweeper.Models
{
    public class UserModel
    {
        //User ID
        public int Id { get; set; }


        //User first name
        [Required]
        [DisplayName("First Name")]
        [StringLength(20, MinimumLength = 4)]
        public string? FirstName { get; set; }

        //User last name
        [Required]
        [DisplayName("Last Name")]
        [StringLength(20, MinimumLength = 4)]
        public string? LastName { get; set; }

        //User Age
        [Required]
        [Range(1, 110, ErrorMessage = "Age must be at least 1 and less than 110")]
        [DisplayName("Age")]
        public int Age { get; set; }

        // User State
        [Required]
        [RegularExpression(@"^[a-zA-Z]{2}$", ErrorMessage = "State must be 2 characters")]
        [DisplayName("State")]
        public string? State { get; set; }

        // User Email
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [DisplayName("Email")]
        public string? Email { get; set; }

        // User username
        [Required]
        [DisplayName("Username")]
        [StringLength(20, MinimumLength = 4)]
        public string? UserName { get; set; }

        // User Password
        [Required]
        [DisplayName("Password")]
        [StringLength(20, MinimumLength = 6)]
        public string? Password { get; set; }

        public UserModel()
        {

        }

        public UserModel(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        public UserModel(int id, string? firstName, string? lastName, int age, string? state, string? email, string? userName, string? password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            State = state;
            Email = email;
            UserName = userName;
            Password = password;
        }
    }

}
