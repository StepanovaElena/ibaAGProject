using System.Collections.Generic;

namespace DataLayer.Entity
{
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanBeDeleted { get; set; } = true;
       
        public List<GroupsPermissions> Permissions { get; set; }

        public List<UsersGroups> Users { get; set; }

        public Groups()
        {
            Permissions = new List<GroupsPermissions>();
            Users = new List<UsersGroups>();
        }
    }
}
