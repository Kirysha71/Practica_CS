using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class StudentGrade
    {
        public double CalculateAverage(List<int> grades)
        {
            if(grades == null || grades.Count == 0)
            {
                throw new ArgumentException("Список оценок не может быть пустым");
            }

            foreach(var grade in grades)
            {
                if(grade < 0 || grade > 100)
                {
                    throw new InvalidGradeException(grade);
                }
            }

            return grades.Average();
        }
    }
}
