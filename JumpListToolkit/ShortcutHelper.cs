using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

internal static class ShortcutHelper
{
    internal static string CreateShortcut(ProcessStartInfo process, string targetPath, string name, string description = "")
    {
        return CreateShortcut(process.FileName, targetPath, name, description, process.Arguments, process.WorkingDirectory);
    }

    internal static string CreateShortcut(string fileName, string targetPath, string name = "", string description = "", string args = "", string workDir = "")
    {
        var link = (IShellLink)new ShellLink();

        if (string.IsNullOrEmpty(name))
            name = Path.GetFileNameWithoutExtension(fileName);

        link.SetPath(fileName);
        link.SetDescription(description ?? name);
        link.SetWorkingDirectory(workDir ?? new FileInfo(fileName).Directory.FullName);
        link.SetArguments(args);

        var result = Path.Combine(targetPath, $"{name}.lnk");

        var file = (IPersistFile)link;
        file.Save(result, false);

        return result;
    }

    internal static string CreateDesktopShortcut(string fileName, string name = "", string description = "", string args = "", string workDir = "")
    {
        var targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        return CreateShortcut(fileName, targetPath, name, description, args, workDir);
    }

    internal static string CreateProgramsShortcut(string fileName, string folder = "", string name = "", string description = "", string args = "", string workDir = "")
    {
        var targetPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs), folder);
        if (!Directory.Exists(targetPath)) Directory.CreateDirectory(targetPath);
        return CreateShortcut(fileName, targetPath, name, description, args, workDir);
    }

    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    internal class ShellLink
    {
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    internal interface IShellLink
    {
        void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd, int fFlags);

        void GetIDList(out IntPtr ppidl);

        void SetIDList(IntPtr pidl);

        void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);

        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

        void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);

        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

        void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);

        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

        void GetHotkey(out short pwHotkey);

        void SetHotkey(short wHotkey);

        void GetShowCmd(out int piShowCmd);

        void SetShowCmd(int iShowCmd);

        void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);

        void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

        void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);

        void Resolve(IntPtr hwnd, int fFlags);

        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }
}