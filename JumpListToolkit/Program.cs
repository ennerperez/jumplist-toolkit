using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Toolkit
{
    internal static partial class Program
    {
        internal static bool IsNewInstance = false;
        internal static Mutex Mutex = new Mutex(true, ApplicationInfo.Guid, out IsNewInstance);
        internal static Assembly Assembly = Assembly.GetExecutingAssembly();

        internal static Dictionary<string, string> CommandArgs => ApplicationInfo.GetCommandLine();

        [STAThread]
        private static void Main()
        {
            Initialize();

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new Forms.FormMain();

            if (IsNewInstance && !CommandArgs.ContainsKey("/settings"))
            {
                Application.Run(mainForm);
                Mutex.ReleaseMutex();
            }
            else
            {
                NewInstanceHandler(null, EventArgs.Empty);

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
            NewInstance?.Invoke(sender, e);
        }

        public static event EventHandler NewInstance;
    }
}