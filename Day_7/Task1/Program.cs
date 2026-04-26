namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentGrade = new StudentGrade();
            try
            {
                var validGrades = new List<int> { 85, 90, 78, 92 };
                double average = studentGrade.CalculateAverage(validGrades);
                Console.WriteLine($"Средний балл: {average:F2}");

                var invalidGrades = new List<int> { 85, 150, 78 };
                studentGrade.CalculateAverage(invalidGrades);
            }
            catch (InvalidGradeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
