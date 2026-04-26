using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    internal class InvalidGradeException : Exception
    {
        public InvalidGradeException(int grade)
            : base($"Некорректная оценка {grade}.")
        {
        } 
    }
}
