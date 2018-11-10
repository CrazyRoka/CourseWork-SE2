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
