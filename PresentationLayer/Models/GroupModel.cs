using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int[] Permissions { get; set; }

        public int[] Membership { get; set; }
    }
}
