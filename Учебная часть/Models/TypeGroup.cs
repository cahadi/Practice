using System;
using System.Collections.Generic;

namespace Учебная_часть.Models
{
    public partial class TypeGroup
    {
        public TypeGroup()
        {
            Groups = new HashSet<Group>();
        }

        public int TypeGroupId { get; set; }
        public string TypeGroupName { get; set; } = null!;

        public virtual ICollection<Group> Groups { get; set; }
    }
}
