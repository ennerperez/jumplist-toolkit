using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Pictograms;
using System.IO;
using System.Linq;
using Toolkit.Models;

namespace Toolkit
{
    internal static partial class Program
    {
        internal static MaterialDesign.IconType Icon => MaterialDesign.IconType.dashboard;

        internal static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            Error = new EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>((object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args) =>
            {
                args.ErrorContext.Handled = true;
            })
        };

        public static JumpList JumpList { get; internal set; }

        internal static void Initialize()
        {
#if DEBUG
            ImageHelper.GetEditorIcon(MaterialDesign.GetImage(Program.Icon, 256, Color.White));
#endif
        }

        public static List<Link> LoadFromFile(string source = "")
        {
            var result = new List<Link>();

            if (string.IsNullOrEmpty(source) && CommandArgs.ContainsKey("/settings"))
                source = CommandArgs["/settings"];

            if (string.IsNullOrEmpty(source))
                source = Path.ChangeExtension(Assembly.Location, ".json");

            if (!string.IsNullOrEmpty(source) && File.Exists(source))
                result = JsonConvert.DeserializeObject<List<Link>>(File.ReadAllText(source), SerializerSettings);
            else
                result = new List<Link>();

            return result;
        }

        public static bool SaveToFile(string target = "", List<Link> source = null)
        {
            if (string.IsNullOrEmpty(target) && CommandArgs.ContainsKey("/settings"))
                target = CommandArgs["/settings"];

            if (string.IsNullOrEmpty(target))
                target = Path.ChangeExtension(Assembly.Location, ".json");

            File.WriteAllText(target, JsonConvert.SerializeObject(source, SerializerSettings));

            return File.Exists(target);
        }

        internal static void RegisterTaskBarActions(List<Link> definition)
        {
            JumpList = JumpList.CreateJumpList();
            JumpList.ClearAllUserTasks();
            JumpList.Refresh();

            var categories = from item in definition
                             where !string.IsNullOrEmpty(item.Category)
                             group item by item.Category into g
                             select new JumpListCustomCategory(g.Key);

            foreach (var item in categories)
            {
                var items = from link in definition
                            where !string.IsNullOrEmpty(link.Category) && link.Category == item.Name
                            select new JumpListLink(link.Path, link.Title)
                            {
                                Arguments = link.Arguments,
                                WorkingDirectory = link.WorkingDirectory,
                                IconReference = !string.IsNullOrEmpty(link.IconLocation) ? new IconReference(link.IconLocation, link.IconIndex) : new IconReference(),
                                ShowCommand = link.ShowCommand
                            };
                item.AddJumpListItems(items.ToArray());
                JumpList.AddCustomCategories(item);
            }

            var tasks = from link in definition
                        where string.IsNullOrEmpty(link.Category)
                        select new JumpListLink(link.Path, link.Title)
                        {
                            Arguments = link.Arguments,
                            WorkingDirectory = link.WorkingDirectory,
                            IconReference = !string.IsNullOrEmpty(link.IconLocation) ? new IconReference(link.IconLocation, link.IconIndex) : new IconReference(),
                            ShowCommand = link.ShowCommand
                        };
            if (tasks != null && tasks.Any())
                JumpList.AddUserTasks(tasks.ToArray());

            JumpList.Refresh();
        }
    }
}