using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entity
{
    public class UsersPermissions
    {
        public int UsersId { get; set; }
        public Users Users { get; set; }

        public int PermissionsId { get; set; }
        public Permissions Permissions { get; set; }
    }
}
