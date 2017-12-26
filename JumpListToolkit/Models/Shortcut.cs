using System.Collections.Generic;

namespace Toolkit.Models
{
    public class Shortcut : Link
    {
        public Shortcut()
        {
            Links = new List<Link>();
        }

        public List<Link> Links { get; set; }

        public int? DefaultLink { get; set; }
    }
}