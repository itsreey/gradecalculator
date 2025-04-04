// this is mostly for the picker in our course entry detail xaml file oops
// the plan was to have this be what handles the converting letter grades into grade points (eg HD -> 7; D -> 6, etc) but uhhhhh that ended up being in courseentry.cs
// does this mean this is redundant?? should i remove this to make my code cleaner??? hmm

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradecalculator.Models
{
    public static class GradeValue
    {
        public static string[] Grades = new string[] { "HD", "D", "C", "P", "F" };

        public static double[] GradeValues = new double[] { 7, 6, 5, 4, 0 };

        public static string[] Units = new string[] { "10", "20", "30", "40" };
    }
}
