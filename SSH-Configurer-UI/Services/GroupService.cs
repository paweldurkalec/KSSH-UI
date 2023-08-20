using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Pages;
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

        public List<Group> SearchByName(string input)
        {
            List<Group> filtered = Groups.Where(group => group.Name.ToLower().Contains(input.ToLower())).ToList();

            return filtered;
        }

        public int AddGroup(Group group)
        {
            Groups.Add(group);
            return 0;
        }
    }
}
