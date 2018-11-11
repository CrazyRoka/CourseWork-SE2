using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsvHelper;
using System.IO;
using SE2.CourseWork.Models;
using SE2.CourseWork.Generators;
using System.Collections.ObjectModel;

namespace SE2.CourseWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GroupTable.ItemsSource = GroupsContainer.Groups;
        }
        private void FindSameBirthdayButtonClick(object sender, RoutedEventArgs e)
        {
            IEnumerable<Student> students = (IEnumerable<Student>)StudentTable.ItemsSource;
            IEnumerable<Professor> professors = (IEnumerable<Professor>)ProfessorTable.ItemsSource;
            if(students == null)
            {
                MessageBox.Show("Введіть дані про студентів", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(professors == null)
            {
                MessageBox.Show("Введіть дані про викладачів", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                foreach(Professor professor in professors)
                {
                    if(professor.Group != null)
                    {
                        var selectedStudents = students.Where(student => student.Group == professor.Group 
                            && student.BirthdayDate.Substring(5).Equals(professor.BirthdayDate.Substring(5)));
                        if(selectedStudents.Count() != 0)
                        {
                            string answer = $"Викладач:\n{professor.ToString()}\nСтуденти:\n";
                            answer += string.Join("\n", selectedStudents);
                            MessageBox.Show(answer, "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
        }
        private void FindLowestMarkButtonClick(object sender, RoutedEventArgs e)
        {
            string answer;
            int course = int.Parse(CourseNumber.Text);
            IEnumerable<Student> students = (IEnumerable<Student>)StudentTable.ItemsSource;
            if(students == null)
            {
                answer = "Введіть дані про студентів";
            }
            else
            {
                students = students.Where(student => student.Course == course);
                if(students.Count() == 0)
                {
                    answer = "Не існує жодного студента на заданому кусрі";
                }
                else
                {
                    Student worstStudent = students.First();
                    foreach (Student current in students)
                    {
                        if (current.AverageScore < worstStudent.AverageScore)
                        {
                            worstStudent = current;
                        }
                    }
                    answer = worstStudent.ToString();
                }
            }
            MessageBox.Show(answer, "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void FindBestMarkButtonClick(object sender, RoutedEventArgs e)
        {
            string answer;
            if (ProfessorTable.SelectedItems.Count == 0)
            {
                answer = "Виберіть викладача для пошуку.";
            }else if(ProfessorTable.SelectedItems.Count > 1)
            {
                answer = "Виберіть лише одного викладача.";
            }
            else
            {
                Professor professor = (Professor)ProfessorTable.SelectedItem;
                if(professor.Group == null)
                {
                    answer = "Даний викладач не є куратором жодної групи.";
                }
                else
                {
                    IEnumerable<Student> students = (IEnumerable<Student>)StudentTable.ItemsSource;
                    if (students != null)
                    {
                        students = students.Where(student => string.Equals(student.GroupName, professor.GroupName));
                        if (students.Count() == 0)
                        {
                            answer = "Група не має жодного студента.";
                        }
                        else
                        {
                            Student bestStudent = students.First();
                            foreach (Student current in students)
                            {
                                if (current.AverageScore > bestStudent.AverageScore)
                                {
                                    bestStudent = current;
                                }
                            }
                            answer = bestStudent.ToString();
                        }
                    }
                    else
                    {
                        answer = "Введіть дані про студентів.";
                    }
                }
            }
            MessageBox.Show(answer, "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void FindButtonClick(object sender, RoutedEventArgs e)
        {
            string text = FindTextBox.Text;
            string answer;
            if(StudentTable.ItemsSource == null)
            {
                answer = "Введіть дані про студентів";
            }
            else if (FindByLastName.IsChecked == true)
            {
                IEnumerable<Student> students = (IEnumerable<Student>)StudentTable.ItemsSource;
                students = students.Where(student => string.Equals(student.LastName, text));
                if (students.Count() == 0) answer = "Не знайдено такого студента";
                else
                {
                    answer = string.Join("\n", students);
                }
            }else if (FindByGroup.IsChecked == true)
            {
                IEnumerable<Student> students = (IEnumerable<Student>)StudentTable.ItemsSource;
                students = students.Where(student => string.Equals(student.GroupName, text));
                if (students.Count() == 0) answer = "Не знайдено такого студента";
                else
                {
                    answer = string.Join("\n", students);
                }
            }
            else if (FindByAverageScore1.IsChecked == true)
            {
                try
                {
                    IEnumerable<Student> students = (IEnumerable<Student>)StudentTable.ItemsSource;
                    students = students.Where(student => decimal.Equals(student.AverageScore, decimal.Parse(text.Replace(',','.'))));
                    if (students.Count() == 0) answer = "Не знайдено такого студента";
                    else
                    {
                        answer = string.Join("\n", students);
                    }
                }
                catch(FormatException)
                {
                    answer = "Неправильне введене число!";
                }
                catch (OverflowException)
                {
                    answer = "Введене число занадто велике (мале)";
                }
            }
            else
            {
                //TODO
                throw new NotImplementedException();
            }
            MessageBox.Show(answer, "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ReadPersons(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                readPersonData(openFileDialog.FileName);
            }
        }
        private void ReadStudents(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                readStudentData(openFileDialog.FileName);
            }
        }

        private void ReadGroups(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                readGroupsData(openFileDialog.FileName);
            }
        }
        private void ReadProfessors(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                readProfessorsData(openFileDialog.FileName);
            }
        }

        private void readStudentData(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            try
            {
                List<Student> students = new List<Student>();
                while (!file.EndOfStream)
                {
                    Student current = new Student();
                    file -= current;
                    students.Add(current);
                }
                StudentTable.ItemsSource = students;
            }
            finally
            {
                file.Close();
            }
        }

        private void readProfessorsData(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            try
            {
                List<Professor> professors = new List<Professor>();
                while (!file.EndOfStream)
                {
                    Professor current = new Professor();
                    file -= current;
                    professors.Add(current);
                }
                ProfessorTable.ItemsSource = professors;
            }
            finally
            {
                file.Close();
            }
        }

        private void readPersonData(string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                using (CsvReader reader = new CsvReader(file))
                {
                    List<Person> persons = new List<Person>(reader.GetRecords<Person>());
                    PersonTable.ItemsSource = persons;
                }
            }
        }

        private void readGroupsData(string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                using (CsvReader reader = new CsvReader(file))
                {
                    reader.Configuration.RegisterClassMap<GroupClassMap>();
                    List<Group> groups = new List<Group>(reader.GetRecords<Group>());
                    foreach(Group group in groups)
                    {
                        if(GroupsContainer.Groups.Select((g) => g.SpecialityFullName.Equals(group.SpecialityFullName) && g.GroupName.Equals(group.GroupName)).Count() == 0)
                        {
                            GroupsContainer.Groups.Add(group);
                        }
                    }
                    GroupTable.ItemsSource = GroupsContainer.Groups;
                }
            }
        }
    }
}
