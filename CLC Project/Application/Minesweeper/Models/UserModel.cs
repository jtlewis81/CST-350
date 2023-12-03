namespace Minesweeper.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public string? State { get; set; }

        public string? Email { get; set; }

        public string? UserName { get; set; }

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
