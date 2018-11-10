using SE2.CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public static class GroupsContainer
    {
        public static ObservableCollection<Group> Groups { get; set; } = new ObservableCollection<Group>();
        public static Group FindOrCreateGroup(string groupName)
        {
            var result = Groups.Where(group => group.GroupName.Equals(groupName));
            if(result.Count() == 0)
            {
                Group group = new Group(groupName);
                Groups.Add(group);
                return group;
            }
            return result.First();
        }
    }
}
