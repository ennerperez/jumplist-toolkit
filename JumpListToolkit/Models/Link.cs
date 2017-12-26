using Microsoft.WindowsAPICodePack.Shell;

namespace Toolkit.Models
{
    public class Link
    {
        public Link()
        {
        }

        public Link(string path, string title) : this()
        {
            Path = path;
            Title = title;
        }

        public Link(string path, string title, string icon, int index = 0) : this(path, title)
        {
            this.IconLocation = icon;
            this.IconIndex = index;
        }

        #region Properties

        //
        // Summary:
        //     Gets or sets the icon reference (location) of the link's icon.
        public string IconLocation { get; set; }

        //
        // Summary:
        //     Gets or sets the icon reference (index) of the link's icon.
        public int IconIndex { get; set; }

        //
        // Summary:
        //     Gets or sets the link's title
        public string Title { get; set; }

        //
        // Summary:
        //     Gets or sets the link's description
        public string Description { get; set; }

        //
        // Summary:
        //     Gets or sets the link's path
        public string Path { get; set; }

        //
        // Summary:
        //     Gets or sets the object's arguments (passed to the command line).
        public string Arguments { get; set; }

        //
        // Summary:
        //     Gets or sets the object's working directory.
        public string WorkingDirectory { get; set; }

        //
        // Summary:
        //     Gets or sets the show command of the launched application.
        public WindowShowCommand ShowCommand { get; set; }

        public string Category { get; set; }

        public Link Clone()
        {
            return new Link(this.Path, this.Title)
            {
                Arguments = this.Arguments,
                Category = this.Category,
                Description = this.Description,
                IconIndex = this.IconIndex,
                IconLocation = this.IconLocation,
                ShowCommand = this.ShowCommand,
                WorkingDirectory = this.WorkingDirectory
            };
        }

        #endregion Properties

        public override string ToString()
        {
            return Title;
        }
    }
}