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
            PersonTable.ItemsSource = new List<Person>();
            StudentTable.ItemsSource = new List<Student>();
            ProfessorTable.ItemsSource = new List<Professor>();
            GroupTable.ItemsSource = GroupsContainer.Groups;
        }
        private void SaveProfessorsClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(fileName);
                    List<Professor> professors = ProfessorTable.ItemsSource as List<Professor>;
                    foreach (Professor professor in professors)
                        writer += professor;
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка роботи з файлом!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    try
                    {
                        writer?.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Помилка закриття файлу!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
        private void DeleteProfessorsClick(object sender, RoutedEventArgs e)
        {
            var professors = (List<Professor>)ProfessorTable.ItemsSource;
            var selected = ProfessorTable.SelectedItems;
            if (professors == null)
            {
                MessageBox.Show("Введіть дані про викладачів", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (selected.Count == 0)
            {
                MessageBox.Show("Виберіть хоча б одного викладача", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                foreach (Professor professor in selected)
                {
                    professor.Group = null;
                    professors.Remove(professor);
                }
                ProfessorTable.ItemsSource = null;
                ProfessorTable.ItemsSource = professors;
                MessageBox.Show("Записи про викладачів видалено", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void AddProfessorClick(object sender, RoutedEventArgs e)
        {
            List<Professor> list = (List<Professor>)ProfessorTable.ItemsSource;
            list.Add(new Professor());
            ProfessorTable.ItemsSource = null;
            ProfessorTable.ItemsSource = list;
        }
        private void SaveStudentsClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(fileName);
                    List<Student> students = StudentTable.ItemsSource as List<Student>;
                    foreach (Student student in students)
                        writer += student;
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка роботи з файлом!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    try
                    {
                        writer?.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Помилка закриття файлу!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
        private void DeleteStudentsClick(object sender, RoutedEventArgs e)
        {
            var students = (List<Student>)StudentTable.ItemsSource;
            var selected = StudentTable.SelectedItems;
            if (students == null)
            {
                MessageBox.Show("Введіть дані про студентів", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (selected.Count == 0)
            {
                MessageBox.Show("Виберіть хоча б одного студента", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                foreach (Student student in selected)
                {
                    student.Group.DeleteStudent(student);
                    student.Group = null;
                    students.Remove(student);
                }
                StudentTable.ItemsSource = null;
                StudentTable.ItemsSource = students;
                MessageBox.Show("Записи про студентів видалено", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void AddStudentClick(object sender, RoutedEventArgs e)
        {
            List<Student> list = (List<Student>)StudentTable.ItemsSource;
            list.Add(new Student());
            StudentTable.ItemsSource = null;
            StudentTable.ItemsSource = list;
        }
        private void SavePersonsClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(fileName);
                    List<Person> persons = PersonTable.ItemsSource as List<Person>;
                    foreach (Person person in persons)
                        writer += person;
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка роботи з файлом!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    try
                    {
                        writer?.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Помилка закриття файлу!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
        private void DeletePersonsClick(object sender, RoutedEventArgs e)
        {
            var persons = (List<Person>)PersonTable.ItemsSource;
            var selected = PersonTable.SelectedItems;
            if (persons == null)
            {
                MessageBox.Show("Введіть дані про персон", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (selected.Count == 0)
            {
                MessageBox.Show("Виберіть хоча б одну персону", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                foreach (Person person in selected) persons.Remove(person);
                PersonTable.ItemsSource = null;
                PersonTable.ItemsSource = persons;
                MessageBox.Show("Записи про персон видалено", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void AddPersonClick(object sender, RoutedEventArgs e)
        {
            List<Person> list = (List<Person>)PersonTable.ItemsSource;
            list.Add(new Person());
            PersonTable.ItemsSource = null;
            PersonTable.ItemsSource = list;
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
                            && string.Equals(student.BirthdayDate.Substring(5), professor.BirthdayDate.Substring(5)));
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
            else
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
            StreamReader file = null;
            try
            {
                file = new StreamReader(fileName);
                List<Student> students = new List<Student>();
                while (!file.EndOfStream)
                {
                    Student current = new Student();
                    file -= current;
                    students.Add(current);
                }
                List<Student> previous = (List<Student>)StudentTable.ItemsSource;
                StudentTable.ItemsSource = null;
                StudentTable.ItemsSource = previous.Concat(students).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка зчитування з файлу", "Зчитування викладачів", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                try
                {
                    file?.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка закривання файлу", "Зчитування викладачів", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void readProfessorsData(string fileName)
        {
            StreamReader file = null;
            try { 
                file = new StreamReader(fileName);
                List<Professor> professors = new List<Professor>();
                while (!file.EndOfStream)
                {
                    Professor current = new Professor();
                    file -= current;
                    professors.Add(current);
                }
                List<Professor> previous = (List<Professor>)ProfessorTable.ItemsSource;
                ProfessorTable.ItemsSource = null;
                ProfessorTable.ItemsSource = previous.Concat(professors).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка зчитування з файлу", "Зчитування викладачів", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                try
                {
                    file?.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка закривання файлу", "Зчитування викладачів", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void readPersonData(string fileName)
        {
            StreamReader file = null;
            try
            {
                file = new StreamReader(fileName);
                List<Person> persons = new List<Person>();
                while (!file.EndOfStream)
                {
                    Person current = new Person();
                    file -= current;
                    persons.Add(current);
                }
                List<Person> previous = (List<Person>)PersonTable.ItemsSource;
                PersonTable.ItemsSource = null;
                PersonTable.ItemsSource = previous.Concat(persons).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка зчитування з файлу", "Зчитування персон", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                try
                {
                    file?.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка закривання файлу", "Зчитування персон", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
