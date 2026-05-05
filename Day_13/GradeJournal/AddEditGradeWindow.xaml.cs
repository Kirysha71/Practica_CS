using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GradeJournal
{
    /// <summary>
    /// Логика взаимодействия для AddEditGradeWindow.xaml
    /// </summary>
    public partial class AddEditGradeWindow : Window
    {
        public Grade GradeData { get; private set; }

        public AddEditGradeWindow(Grade grade = null)
        {
            InitializeComponent();

            if (grade != null)
            {
                GradeData = new Grade
                {
                    StudentName = grade.StudentName,
                    Subject = grade.Subject,
                    Value = grade.Value,
                    Comment = grade.Comment,
                    Date = grade.Date
                };

                txtStudent.Text = GradeData.StudentName;
                txtSubject.Text = GradeData.Subject;
                txtGrade.Text = GradeData.Value.ToString();
                txtComment.Text = GradeData.Comment;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudent.Text) ||
                string.IsNullOrWhiteSpace(txtSubject.Text) ||
                string.IsNullOrWhiteSpace(txtGrade.Text))
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtGrade.Text, out int gradeValue) || gradeValue < 1 || gradeValue > 5)
            {
                MessageBox.Show("Оценка должна быть числом от 1 до 5!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            GradeData = new Grade
            {
                StudentName = txtStudent.Text,
                Subject = txtSubject.Text,
                Value = gradeValue,
                Comment = txtComment.Text,
                Date = DateTime.Now
            };

            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
