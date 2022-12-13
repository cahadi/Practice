using System;
using System.Collections.Generic;

namespace Учебная_часть.Models
{
    public partial class KindOfTypeDiscipline
    {
        public KindOfTypeDiscipline()
        {
            TypeDisciplines = new HashSet<TypeDiscipline>();
        }

        public int KindOfTypeDisciplinesId { get; set; }
        public string KindOfTypeDisciplines { get; set; } = null!;

        public virtual ICollection<TypeDiscipline> TypeDisciplines { get; set; }
    }
}
