using System.Reflection.Metadata;

namespace SSH_Configurer_UI.Model
{
    public class NavMenuItem
    {
        public string DisplayedText { get; set; }
        public string Href { get; set; }
        public int Depth { get; set; }
        public string IconNotExpanded { get; set; }
        public string IconExpanded { get; set; }
        public List<NavMenuItem> SubItems { get; set; }

        public NavMenuItem(string displayedText, string href, int depth, string iconNotExpanded, string iconExpanded, List<NavMenuItem> subItems)
        {
            DisplayedText = displayedText;
            Href = href;
            Depth = depth;
            IconNotExpanded = iconNotExpanded;
            IconExpanded = iconExpanded;
            SubItems = subItems;
        }

        public NavMenuItem() { }
    }
}

