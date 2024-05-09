using System;
using System.Collections.Generic;

namespace _11_gyak.Models
{
    public partial class Day
    {
        public Day()
        {
            Lessons = new HashSet<Lesson>();
        }

        public byte DayId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
