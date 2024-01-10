namespace RegisterAndLoginApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return "Username: " + UserName + " | Passowrd: " + Password;
        }
    }
}
