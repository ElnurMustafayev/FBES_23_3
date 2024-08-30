using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedApp.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int CountryId { get; set; }

        public override string ToString() => $"{Id}: {Name}, {Salary}$";
    }
}
