using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using GradeJournal.Models;
using GradeJournal.ViewModels;

namespace GradeJournal
{
    public partial class MainWindow : Window
    {
        public MainWindow(UserModel user)
        {
            InitializeComponent();
            DataContext = new JournalViewModel(user);
            Title = $"Электронный журнал - {user.FullName}";
        }

        private void StudentCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBorder && clickedBorder.Tag is StudentModel clickedStudent)
            {
                if (DataContext is JournalViewModel vm)
                {
                    if (vm.SelectedStudent == clickedStudent)
                    {
                        vm.SelectedStudent = null;
                        ResetAllBordersVisuals(null);
                        return;
                    }

                    vm.SelectedStudent = clickedStudent;

                    ResetAllBordersVisuals(clickedBorder);

                    HighlightBorder(clickedBorder);

                    PlayClickAnimation(clickedBorder);
                }
            }
        }

        private void ResetAllBordersVisuals(Border excludeBorder)
        {
            var itemsControl = FindVisualChild<ItemsControl>(this);

            if (itemsControl != null)
            {
                foreach (var item in itemsControl.Items)
                {
                    var container = itemsControl.ItemContainerGenerator.ContainerFromItem(item);
                    if (container is FrameworkElement frameworkElement)
                    {
                        var border = FindVisualChild<Border>(frameworkElement);
                        if (border != null && border != excludeBorder)
                        {
                            border.BorderBrush = new SolidColorBrush(Color.FromRgb(204, 204, 204));
                            border.Background = Brushes.White;

                            if (border.Tag is StudentModel student)
                            {
                                if (student.AverageGrade <= 2.5)
                                {
                                    border.Background = new SolidColorBrush(Color.FromRgb(255, 238, 238));
                                    border.BorderBrush = Brushes.Red;
                                    border.BorderThickness = new Thickness(2);
                                }
                                else if (student.AverageGrade <= 3.0)
                                {
                                    border.Background = new SolidColorBrush(Color.FromRgb(255, 245, 230));
                                    border.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 165, 0));
                                    border.BorderThickness = new Thickness(2);
                                }
                                else
                                {
                                    border.BorderThickness = new Thickness(1);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void HighlightBorder(Border border)
        {
            border.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            border.Background = new SolidColorBrush(Color.FromRgb(227, 242, 253));
            border.BorderThickness = new Thickness(2);
        }

        private void PlayClickAnimation(Border border)
        {
            var storyboard = new Storyboard();
            var scaleTransform = new ScaleTransform(1, 1);

            border.RenderTransform = new TransformGroup
            {
                Children = new TransformCollection
                {
                    new TranslateTransform(),
                    scaleTransform
                }
            };

            var scaleUp = new DoubleAnimation(0.98, TimeSpan.FromMilliseconds(100));
            Storyboard.SetTarget(scaleUp, scaleTransform);
            Storyboard.SetTargetProperty(scaleUp, new PropertyPath(ScaleTransform.ScaleXProperty));
            storyboard.Children.Add(scaleUp);

            var scaleUpY = new DoubleAnimation(0.98, TimeSpan.FromMilliseconds(100));
            Storyboard.SetTarget(scaleUpY, scaleTransform);
            Storyboard.SetTargetProperty(scaleUpY, new PropertyPath(ScaleTransform.ScaleYProperty));
            storyboard.Children.Add(scaleUpY);

            var scaleDown = new DoubleAnimation(1, TimeSpan.FromMilliseconds(100)) { BeginTime = TimeSpan.FromMilliseconds(100) };
            Storyboard.SetTarget(scaleDown, scaleTransform);
            Storyboard.SetTargetProperty(scaleDown, new PropertyPath(ScaleTransform.ScaleXProperty));
            storyboard.Children.Add(scaleDown);

            var scaleDownY = new DoubleAnimation(1, TimeSpan.FromMilliseconds(100)) { BeginTime = TimeSpan.FromMilliseconds(100) };
            Storyboard.SetTarget(scaleDownY, scaleTransform);
            Storyboard.SetTargetProperty(scaleDownY, new PropertyPath(ScaleTransform.ScaleYProperty));
            storyboard.Children.Add(scaleDownY);

            storyboard.Begin();
        }

        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild)
                    return typedChild;

                var childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                    return childOfChild;
            }
            return null;
        }
    }
}