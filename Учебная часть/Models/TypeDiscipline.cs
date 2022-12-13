using System;
using System.Collections.Generic;

namespace Учебная_часть.Models
{
    public partial class TypeDiscipline
    {
        public TypeDiscipline()
        {
            Disciplines = new HashSet<Discipline>();
        }

        public int TypeDisciplinesId { get; set; }
        public string TypeDisciplines { get; set; } = null!;
        public int KindOfTypeDisciplinesId { get; set; }

        public virtual KindOfTypeDiscipline KindOfTypeDisciplines { get; set; } = null!;
        public virtual ICollection<Discipline> Disciplines { get; set; }
    }
}
