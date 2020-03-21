using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entity
{
    public class GroupsPermissions
    {
        public int GroupsId { get; set; }
        public Groups Groups { get; set; }

        public int PermissionsId { get; set; }
        public Permissions Permissions { get; set; }
    }
}
