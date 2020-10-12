using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacanciesInformation
{
    public class ServiceData
    {
        private int FirstSalary { get; set; }
        private int SecondSalary { get; set; }
        public List<string> ProfessionsWithFirstSalary { get; set; }
        public List<string> SkillsForSalaryFirstSalary { get; set; }
        public List<string> ProfessionsWithSecondSalary { get; set; }
        public List<string> SkillsForSecondSalary { get; set; }

        public ServiceData(int FirstSalary, int SecondSalary)
        {
            this.FirstSalary = FirstSalary;
            this.SecondSalary = SecondSalary;
            ProfessionsWithFirstSalary = new List<string>();
            SkillsForSalaryFirstSalary = new List<string>();
            ProfessionsWithSecondSalary = new List<string>();
            SkillsForSecondSalary = new List<string>();
        }
    }
}
