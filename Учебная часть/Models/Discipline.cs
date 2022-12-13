using System;
using System.Collections.Generic;

namespace Учебная_часть.Models
{
    public partial class Discipline
    {
        public int DisciplineId { get; set; }
        public string? DisciplineIndex { get; set; }
        public string DisciplineName { get; set; } = null!;
        public int TypeDisciplinesId { get; set; }

        public virtual TypeDiscipline TypeDisciplines { get; set; } = null!;
    }
}
