using System;
using System.Collections.Generic;

namespace Учебная_часть.Models
{
    public partial class Group
    {
        public int GroupId { get; set; }
        public int GroupNumber { get; set; }
        public int GroupCountStudent { get; set; }
        public int? TypeGroupId { get; set; }

        public virtual TypeGroup? TypeGroup { get; set; }
    }
}
