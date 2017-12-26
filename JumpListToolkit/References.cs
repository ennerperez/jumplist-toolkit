// ----------------------------------------
// References
// Version 1.0.2
// Updated 2018-12-26
// ----------------------------------------

using Octokit;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

#if DEBUG

namespace System.Drawing
{
    /// <summary>
    /// Provides helper methods for imaging
    /// </summary>
    internal static partial class ImageHelper
    {
        /// <summary>
        /// Converts a PNG image to a icon (ico)
        /// </summary>
        /// <param name="input">The input stream</param>
        /// <param name="output">The output stream</param>
        /// <param name="size">The size (16x16 px by default)</param>
        /// <param name="preserveAspectRatio">Preserve the aspect ratio</param>
        /// <returns>Wether or not the icon was succesfully generated</returns>
        internal static bool ConvertToIcon(Stream input, Stream output, int size = 16, bool preserveAspectRatio = false)
        {
            Bitmap inputBitmap = (Bitmap)Bitmap.FromStream(input);
            if (inputBitmap != null)
            {
                int width, height;
                if (preserveAspectRatio)
                {
                    width = size;
                    height = inputBitmap.Height / inputBitmap.Width * size;
                }
                else
                {
                    width = height = size;
                }
                Bitmap newBitmap = new Bitmap(inputBitmap, new Size(width, height));
                if (newBitmap != null)
                {
                    // save the resized png into a memory stream for future use
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        newBitmap.Save(memoryStream, ImageFormat.Png);

                        BinaryWriter iconWriter = new BinaryWriter(output);
                        if (output != null && iconWriter != null)
                        {
                            // 0-1 reserved, 0
                            iconWriter.Write((byte)0);
                            iconWriter.Write((byte)0);

                            // 2-3 image type, 1 = icon, 2 = cursor
                            iconWriter.Write((short)1);

                            // 4-5 number of images
                            iconWriter.Write((short)1);

                            // image entry 1
                            // 0 image width
                            iconWriter.Write((byte)width);
                            // 1 image height
                            iconWriter.Write((byte)height);

                            // 2 number of colors
                            iconWriter.Write((byte)0);

                            // 3 reserved
                            iconWriter.Write((byte)0);

                            // 4-5 color planes
                            iconWriter.Write((short)0);

                            // 6-7 bits per pixel
                            iconWriter.Write((short)32);

                            // 8-11 size of image data
                            iconWriter.Write((int)memoryStream.Length);

                            // 12-15 offset of image data
                            iconWriter.Write((int)(6 + 16));

                            // write image data
                            // png data must contain the whole png data file
                            iconWriter.Write(memoryStream.ToArray());

                            iconWriter.Flush();

                            return true;
                        }
                    }
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Converts a PNG image to a icon (ico)
        /// </summary>
        /// <param name="inputPath">The input path</param>
        /// <param name="outputPath">The output path</param>
        /// <param name="size">The size (16x16 px by default)</param>
        /// <param name="preserveAspectRatio">Preserve the aspect ratio</param>
        /// <returns>Wether or not the icon was succesfully generated</returns>
        internal static bool ConvertToIcon(string inputPath, string outputPath, int size = 16, bool preserveAspectRatio = false)
        {
            using (FileStream inputStream = new FileStream(inputPath, IO.FileMode.Open))
            using (FileStream outputStream = new FileStream(outputPath, IO.FileMode.OpenOrCreate))
            {
                return ConvertToIcon(inputStream, outputStream, size, preserveAspectRatio);
            }
        }

        internal static bool GetEditorIcon(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (Graphics gfx = Graphics.FromImage(bmp))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(43, 43, 43)))
            {
                gfx.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
                gfx.DrawImage(img, 0, 0);
            }

            var assemblyName = Assembly.GetEntryAssembly().GetName().Name;

            bmp.Save(@"..\..\.editoricon.png");
            ConvertToIcon(@"..\..\.editoricon.png", string.Format(@"..\..\{0}\App.ico", assemblyName), (img.Width + img.Height) / 2, true);

            return true;
        }
    }
}

namespace System.Windows.Forms
{
    internal static partial class FormHelper
    {
        public static void ExtractResources(Image image, string name)
        {
            if (image != null)
            {
                var assemblyName = Assembly.GetEntryAssembly().GetName().Name;
                var dirPath = string.Format(@"..\..\{0}\Resources\", assemblyName);
                if (!System.IO.Directory.Exists(dirPath))
                    System.IO.Directory.CreateDirectory(dirPath);
                image.Save(string.Format(@"..\..\{0}\Resources\{1}.png", assemblyName, name));
            }
        }

        public static void ExtractResources(ToolStrip source)
        {
            foreach (var item in source.Items.OfType<ToolStripButton>().Where(i => i.Image != null))
                ExtractResources(item.Image, item.Name);
            foreach (var item in source.Items.OfType<ToolStripDropDownButton>().Where(i => i.Image != null))
                ExtractResources(item.Image, item.Name);
        }
    }
}

#endif

namespace System.Windows.Forms
{
    internal static partial class FormHelper
    {
        public static Rectangle GetWorkingArea()
        {
            int minx, miny, maxx, maxy;
            minx = miny = int.MaxValue;
            maxx = maxy = int.MinValue;

            foreach (Screen screen in Screen.AllScreens)
            {
                var bounds = screen.Bounds;
                minx = Math.Min(minx, bounds.X);
                miny = Math.Min(miny, bounds.Y);
                maxx = Math.Max(maxx, bounds.Right);
                maxy = Math.Max(maxy, bounds.Bottom);
            }

            return new System.Drawing.Rectangle(0, 0, (maxx - minx), (maxy - miny));
        }
    }

    internal class BufferedPanel : Panel
    {
        #region Public Constructors

        public BufferedPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }

        #endregion Public Constructors
    }
}

namespace System.Reflection
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    public class GitHubAttribute : Attribute
    {
        public GitHubAttribute()
        {
        }

        public GitHubAttribute(string owner, string repo, string assetName = "") : base()
        {
            Owner = owner;
            Repo = repo;
            AssetName = assetName;
        }

        public string Owner { get; private set; }
        public string Repo { get; private set; }
        public string AssetName { get; private set; }

        public override string ToString()
        {
            return $"https://github.com/{Owner}/{Repo}";
        }
    }

    internal static class ApplicationInfo
    {
        public static Assembly Assembly => Assembly.GetCallingAssembly();

        public static Version Version => ApplicationInfo.Assembly.GetName().Version;
        public static string Title => ApplicationInfo.Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
        public static string Product => ApplicationInfo.Assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
        public static string Description => ApplicationInfo.Assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
        public static string Copyright => ApplicationInfo.Assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
        public static string Company => ApplicationInfo.Assembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company;
    }

    internal static class GitHubInfo
    {
        public static string Repo => ApplicationInfo.Assembly.GetCustomAttribute<GitHubAttribute>().ToString();
        public static string Owner => ApplicationInfo.Assembly.GetCustomAttribute<GitHubAttribute>().Owner;
        public static string Name => ApplicationInfo.Assembly.GetCustomAttribute<GitHubAttribute>().Repo;
        public static string AssetName => ApplicationInfo.Assembly.GetCustomAttribute<GitHubAttribute>().AssetName;

        public static Release LatestRelease { get; set; }

        public async static Task<Release> GetLatestReleaseAsync()
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue(ApplicationInfo.Title, ApplicationInfo.Version.ToString()));
                return await client.Repository.Release.GetLatest(GitHubInfo.Owner, GitHubInfo.Repo);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public async static Task CheckForUpdateAsync()
        {
            try
            {
                LatestRelease = await GetLatestReleaseAsync();
                if (ApplicationInfo.Version < LatestRelease.GetVersion())
                {
                    var updateMessage = Toolkit.Messages.NewVersion;
                    updateMessage = updateMessage.Replace("{VERSION}", LatestRelease.GetVersion().ToString());
                    updateMessage = updateMessage.Replace("{CREATEDAT}", LatestRelease.CreatedAt.UtcDateTime.ToShortDateString());
                    if (MessageBox.Show(updateMessage, ApplicationInfo.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var assetName = GitHubInfo.AssetName;
                        if (string.IsNullOrEmpty(assetName)) assetName = $"{ApplicationInfo.Product}.zip";
                        var assetUrl = LatestRelease.Assets.FirstOrDefault(m => m.Name == assetName);
                        var url = LatestRelease.AssetsUrl;
                        if (assetUrl != null) url = assetUrl.BrowserDownloadUrl;
                        if (string.IsNullOrEmpty(url)) url = GitHubInfo.Repo;
                        if (!string.IsNullOrEmpty(url)) Process.Start(url);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static Version GetVersion(this Release release)
        {
            Version.TryParse(release.TagName.Replace("v", ""), out Version result);
            return result;
        }
    }
}