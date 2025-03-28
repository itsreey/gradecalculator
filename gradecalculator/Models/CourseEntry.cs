// this is the model for one course entry in our list of courses taken

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradecalculator.Models
{
    [Table("courses")]
    public class CourseEntry
    {
        [PrimaryKey, AutoIncrement]
        public int entryId { get; set; }
        public string courseName { get; set; }
        public string creditUnits { get; set; }
        public string grade {  get; set; }


        private double unitsvalue;
        public double UnitsValue
        {
            get
            {
                return unitsvalue;
            }
            set
            {
                if (creditUnits == "10")
                {
                    unitsvalue = 10.0;
                } else if (creditUnits == "20")
                {
                    unitsvalue = 20.0;
                } else if (creditUnits == "30")
                {
                    unitsvalue = 30.0;
                } else
                {
                    unitsvalue = 40.0;
                }
            }
        }

        private double gradesvalue;
        public double GradesValue
        {
            get
            {
                return gradesvalue;
            }
            set
            {
                if (grade == "HD")
                {
                    gradesvalue = 7;
                } else if (grade == "D")
                {
                    gradesvalue = 6;
                } else if (grade == "C")
                {
                    gradesvalue = 5;
                } else if (grade == "P")
                {
                    gradesvalue = 4;
                } else
                {
                    gradesvalue = 0;
                }
            }
        }
    
    }
}
