using gradecalculator.Models;
using gradecalculator.ViewModels;

namespace gradecalculator
{
    public partial class Calculator
    {

        /* GPA = total grade points / total units
         * grade points = grade value x units
         */

        private double gpa;
        private double totalunits;
        private double totalgradevalue;

        public Calculator(List<CourseEntry> CourseList)
        {
            gpa = 0;
            totalunits = 0;
            totalgradevalue = 0;

            for (int i = 0; i < CourseList.Count; i++)
            {
                // for each item in the list, multiply grade value by units, and then add all up
                totalgradevalue += (CourseList[i].GradesValue * CourseList[i].UnitsValue);

                // add each item's units to total units
                totalunits += CourseList[i].UnitsValue;
            }

            GetResult();

        }

        public double GetResult()
        {
            gpa = totalgradevalue / totalunits;
            var result = Math.Round(gpa, 2);
            return result;
        }

    }
}
