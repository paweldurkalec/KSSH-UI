using static SSH_Configurer_UI.Data.DataTypes;

namespace SSH_Configurer_UI.Services
{
    public class GroupService
    {
        private static readonly Group[] Groups = new[]
        {
            new Group(0, "Room1", 0, new List<int>(){0,1,2}),
            new Group(1, "Room1", 1, new List<int>(){3,4})

        };

        public List<Group> GetAllGroups()
        {
            return new List<Group>(Groups);
        }
    }
}
