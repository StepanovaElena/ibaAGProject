using System.Collections.Generic;

namespace DataLayer.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool CanBeDeleted { get; set; } = true;

        public List<UsersPermissions> Permissions { get; set; }

        public List<UsersGroups> Groups { get; set; }

        public Users()
        {
            Permissions = new List<UsersPermissions>();
            Groups = new List<UsersGroups>();
        }
    }
}
