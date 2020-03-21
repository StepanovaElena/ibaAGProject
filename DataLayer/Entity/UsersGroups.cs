using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entity
{
    public class UsersGroups
    {
        public int UsersId { get; set; }
        public Users Users { get; set; }

        public int GroupsId { get; set; }
        public Groups Groups { get; set; }
    }
}
