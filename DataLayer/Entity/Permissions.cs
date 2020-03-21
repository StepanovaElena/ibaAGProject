using DataLayer.Entity;
using System.Collections.Generic;

namespace DataLayer
{
    public class Permissions
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<GroupsPermissions> Groups { get; set; }

        public List<UsersPermissions> Users { get; set; }

        public Permissions()
        {
            Groups = new List<GroupsPermissions>();
            Users = new List<UsersPermissions>();
        }
    }
}
