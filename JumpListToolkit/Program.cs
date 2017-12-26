using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Pictograms;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Toolkit.Models;

namespace Toolkit
{
    internal static class Program
    {
        internal static bool isNewInstance = false;
        internal static Mutex mutex = new Mutex(true, "{4296dd60-fcea-446d-86cc-35c0407dff33}", out isNewInstance);
        internal static Assembly Assembly = Assembly.GetExecutingAssembly();

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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
#if DEBUG
            ImageHelper.GetEditorIcon(MaterialDesign.GetImage(MaterialDesign.IconType.dashboard, 256, Color.White));
#endif

            InitializeArgs();

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new Forms.FormMain();

            if (isNewInstance && !CommandArgs.ContainsKey("/settings"))
            {
                Application.Run(mainForm);
                mutex.ReleaseMutex();
            }
            else
            {
                var links = LoadFromFile(CommandArgs["/settings"]);
                mainForm.Visible = false;
                mainForm.WindowState = FormWindowState.Minimized;
                mainForm.Shown += (s, v) =>
                {
                    if (links != null)
                        RegisterTaskBarActions(links);
                    mainForm.Close();
                };
                Application.Run(mainForm);
            }
        }

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        private static void NewInstanceHandler(object sender, EventArgs e)
        {
        }

        internal static Dictionary<string, string> CommandArgs { get; private set; }

        internal static void InitializeArgs()
        {
            CommandArgs = new Dictionary<string, string>();

            var assembly = string.Format(@"""{0}"" ", Assembly.GetExecutingAssembly().Location);
            var collection = Environment.CommandLine.Replace(assembly, "").Split(' ').Select(a => a.ToLower()).ToList();

            if (collection.Any())
                foreach (var item in collection.Where(m => m.StartsWith("/")))
                    if (collection.Count - 1 > collection.IndexOf(item))
                        CommandArgs.Add(item.ToLower(), collection[collection.IndexOf(item) + 1].Replace(@"""", @""));
                    else
                        CommandArgs.Add(item.ToLower(), null);
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