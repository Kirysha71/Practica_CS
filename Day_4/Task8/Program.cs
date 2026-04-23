using System;

namespace Task8
{
    class Program
    {
    
        static void AddComplex(in double real1, in double imaginary1,
                          in double real2, in double imaginary2,
                          out (double real, double imaginary) result)
        {
            result.real = real1 + real2;
            result.imaginary = imaginary1 + imaginary2;
        }
        static void AddComplex(in (double real, double imaginary) complex1,
                              in (double real, double imaginary) complex2,
                              out (double real, double imaginary) result)
        {
            result.real = complex1.real + complex2.real;
            result.imaginary = complex1.imaginary + complex2.imaginary;
        }

        static void Main()
        {
            double r1 = 1.0, i1 = 2.0;
            double r2 = 3.0, i2 = 4.0;
            AddComplex(in r1, in i1, in r2, in i2, out var sum1);
            Console.WriteLine($"AddComplex(1.0, 2.0, 3.0, 4.0) = ({sum1.real}, {sum1.imaginary})");

            var complexA = (1.0, 2.0);
            var complexB = (3.0, 4.0);
            AddComplex(in complexA, in complexB, out var sum2);
            Console.WriteLine($"AddComplex((1.0, 2.0), (3.0, 4.0)) = ({sum2.real}, {sum2.imaginary})");

            double r3 = 5.5, i3 = 3.2;
            double r4 = 2.1, i4 = 4.8;
            AddComplex(in r3, in i3, in r4, in i4, out var sum3);
            Console.WriteLine($"AddComplex(5.5, 3.2, 2.1, 4.8) = ({sum3.real}, {sum3.imaginary})");

            var complexC = (-1.0, 2.5);
            var complexD = (3.0, -4.5);
            AddComplex(in complexC, in complexD, out var sum4);
            Console.WriteLine($"AddComplex((-1.0, 2.5), (3.0, -4.5)) = ({sum4.real}, {sum4.imaginary})");
        }
    }
}