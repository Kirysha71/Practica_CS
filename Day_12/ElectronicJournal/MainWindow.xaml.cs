using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ElectronicJournal
{
    public partial class MainWindow : Window
    {
        private List<Student> students;

        public MainWindow()
        {
            InitializeComponent();

            students = new List<Student>
            {
                new Student { Name = "Кирюшка", Grade = "", Comment = "" },
                new Student { Name = "Патрик", Grade = "", Comment = "" },
                new Student { Name = "Артемкинс", Grade = "", Comment = "" },
                new Student { Name = "Максончег", Grade = "", Comment = "" },
                new Student { Name = "Эль Павлино", Grade = "", Comment = "" }
            };

            dgJournal.ItemsSource = students;
        }

        private void BtnAddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (dgJournal.SelectedItem is Student selectedStudent)
            {
                selectedStudent.Grade = "10";
                selectedStudent.Comment = "ЧОТКА";
                dgJournal.Items.Refresh();

                MessageBox.Show($"Оценка добавлена: {selectedStudent.Name}", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите студента из таблицы", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Журнал сохранен!", "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}