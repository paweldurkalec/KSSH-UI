using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Pages;
using SSH_Configurer_UI.Pages.List;
using static System.Net.Mime.MediaTypeNames;

namespace SSH_Configurer_UI.Services
{
    public class GroupService
    {
        private List<Group> Groups = new()
        {
            new Group(0, "Room1", 0, new List<int>(){0,1,2}),
            new Group(1, "Room1", 1, new List<int>(){3,4})

        };

        public List<Group> GetAllGroups()
        {
            return Groups;
        }

        public Group? GetById(int id)
        {
            return Groups.FirstOrDefault(group => group.Id == id, null);
        }

        public List<Group> SearchByName(string input)
        {
            List<Group> filtered = Groups.Where(group => group.Name.ToLower().Contains(input.ToLower())).ToList();

            return filtered;
        }

        public int UpdateGroup(int id, Group group)
        {
            int index = Groups.IndexOf(Groups.FirstOrDefault(group => group.Id == id));
            if (index != -1)
            {
                Groups[index] = group;
                return 0;
            }
            return -1;
        }

        public int AddGroup(Group group)
        {
            Groups.Add(group);
            return 0;
        }

        public int RemoveGroup(Group group)
        {
            Groups.Remove(group);
            return 0;
        }
    }
}
