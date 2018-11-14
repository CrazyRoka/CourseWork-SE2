using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using SE2.CourseWork.Models;

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
                    MessageBox.Show("Помилка роботи з файлом!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    try
                    {
                        writer?.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Помилка закриття файлу!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Введіть дані про викладачів", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (selected.Count == 0)
            {
                MessageBox.Show("Виберіть хоча б одного викладача", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            list.Add(Randomizer.generateProfessor());
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
                    MessageBox.Show("Помилка роботи з файлом!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    try
                    {
                        writer?.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Помилка закриття файлу!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Введіть дані про студентів", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (selected.Count == 0)
            {
                MessageBox.Show("Виберіть хоча б одного студента", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            list.Add(Randomizer.generateStudent());
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
                    MessageBox.Show("Помилка роботи з файлом!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    try
                    {
                        writer?.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Помилка закриття файлу!", "Результат збереження", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Введіть дані про персон", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (selected.Count == 0)
            {
                MessageBox.Show("Виберіть хоча б одну персону", "Результат видалення", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            list.Add(Randomizer.generatePerson());
            PersonTable.ItemsSource = null;
            PersonTable.ItemsSource = list;
        }
        // Знаходження студентів, які мають день народження одного дня з куратором
        private void FindSameBirthdayButtonClick(object sender, RoutedEventArgs e)
        {
            IEnumerable<Student> students = (IEnumerable<Student>)StudentTable.ItemsSource;
            IEnumerable<Professor> professors = (IEnumerable<Professor>)ProfessorTable.ItemsSource;
            if(students == null)
            {
                MessageBox.Show("Введіть дані про студентів", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if(professors == null)
            {
                MessageBox.Show("Введіть дані про викладачів", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                bool used = false;
                foreach(Professor professor in professors)
                {
                    if(professor.Group != null)
                    {
                        var selectedStudents = students.Where(student => student.Group == professor.Group 
                            && string.Equals(student.BirthdayDate.Substring(5), professor.BirthdayDate.Substring(5)));
                        if(selectedStudents.Count() != 0)
                        {
                            used = true;
                            string answer = $"Викладач:\n{professor.ToString()}\nСтуденти:\n";
                            answer += string.Join("\n", selectedStudents);
                            MessageBox.Show(answer, "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                if(!used)
                    MessageBox.Show("Не знайденого жодного результату", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        // знайти студента з найнижчою оцінкою для заданого курсу
        private void FindLowestMarkButtonClick(object sender, RoutedEventArgs e)
        {
            int course = int.Parse(CourseNumber.Text);
            IEnumerable<Student> students = (IEnumerable<Student>)StudentTable.ItemsSource;
            if(students == null)
            {
                MessageBox.Show("Введіть дані про студентів", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                students = students.Where(student => student.Course == course);
                if(students.Count() == 0)
                {
                    MessageBox.Show("Не існує жодного студента на заданому курсі", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                    MessageBox.Show(worstStudent.ToString(), "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        // знайти студента з найкращою оцінкою для заданого куратора групи
        private void FindBestMarkButtonClick(object sender, RoutedEventArgs e)
        {
            if (ProfessorTable.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть викладача для пошуку.", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Warning);
            }else if(ProfessorTable.SelectedItems.Count > 1)
            {
                MessageBox.Show("Виберіть лише одного викладача.", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Professor professor = (Professor)ProfessorTable.SelectedItem;
                if(professor.Group == null)
                {
                    MessageBox.Show("Даний викладач не є куратором жодної групи.", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    IEnumerable<Student> students = (IEnumerable<Student>)StudentTable.ItemsSource;
                    if (students != null)
                    {
                        students = students.Where(student => string.Equals(student.GroupName, professor.GroupName));
                        if (students.Count() == 0)
                        {
                            MessageBox.Show("Група не має жодного студента.", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                            MessageBox.Show(bestStudent.ToString(), "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введіть дані про студентів.", "Результат пошуку", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
        // пошук студентів за критерієм
        private void FindButtonClick(object sender, RoutedEventArgs e)
        {
            string text = FindTextBox.Text;
            string answer;
            if(StudentTable.ItemsSource == null || (StudentTable.ItemsSource as IEnumerable<Student>).Count() == 0)
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
                catch (Exception)
                {
                    answer = "Помилка запиту";
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
                MessageBox.Show("Помилка зчитування з файлу", "Зчитування викладачів", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                try
                {
                    file?.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка закривання файлу", "Зчитування викладачів", MessageBoxButton.OK, MessageBoxImage.Error);
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
            catch (Exception exs)
            {
                MessageBox.Show("Помилка зчитування з файлу", "Зчитування викладачів", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                try
                {
                    file?.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка закривання файлу", "Зчитування викладачів", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Помилка зчитування з файлу", "Зчитування персон", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                try
                {
                    file?.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Помилка закривання файлу", "Зчитування персон", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
