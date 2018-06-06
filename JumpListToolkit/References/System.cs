// ----------------------------------------
// System References
// Version 1.1.0
// Updated 2017-12-26
// ----------------------------------------

using GitHub;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
#if DEBUG

    namespace Drawing
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
                using (FileStream inputStream = new FileStream(inputPath, FileMode.Open))
                using (FileStream outputStream = new FileStream(outputPath, FileMode.OpenOrCreate))
                {
                    return ConvertToIcon(inputStream, outputStream, size, preserveAspectRatio);
                }
            }

            internal static bool GetEditorIcon(Image img)
            {
                Bitmap bmp = new Bitmap(img.Width, img.Height);
                using (Graphics gfx = Graphics.FromImage(bmp))
                using (SolidBrush brush = new SolidBrush(Toolkit.Properties.Settings.Default.BackgroundColor))
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

#endif

    namespace Windows
    {
        namespace Forms
        {
#if DEBUG

            internal static partial class FormHelper
            {
                public static void ExtractResources(Image image, string name)
                {
                    if (image != null)
                    {
                        var assemblyName = Assembly.GetEntryAssembly().GetName().Name;
                        var dirPath = string.Format(@"..\..\{0}\Resources\", assemblyName);
                        if (!Directory.Exists(dirPath))
                            Directory.CreateDirectory(dirPath);
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

#endif

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

                    return new Rectangle(0, 0, (maxx - minx), (maxy - miny));
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
    }

    namespace Reflection
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

            public static string Guid => ApplicationInfo.Assembly.GetCustomAttribute<GuidAttribute>().Value;

            internal static Dictionary<string, string> GetCommandLine()
            {
                var commandArgs = new Dictionary<string, string>();

                var assembly = string.Format(@"""{0}"" ", Assembly.GetExecutingAssembly().Location);
                var collection = Environment.CommandLine.Replace(assembly, "").Split(' ').Select(a => a.ToLower()).ToList();

                if (collection.Any())
                    foreach (var item in collection.Where(m => m.StartsWith("/")))
                        if (collection.Count - 1 > collection.IndexOf(item))
                            commandArgs.Add(item.ToLower(), collection[collection.IndexOf(item) + 1].Replace(@"""", @""));
                        else
                            commandArgs.Add(item.ToLower(), null);

                return commandArgs;
            }
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
                    using (var client = new HttpClient())
                    {
                        var url = new Uri($"https://api.github.com/repos/{GitHubInfo.Owner}/{GitHubInfo.Name}/releases/latest");
                        client.DefaultRequestHeaders.Add("User-Agent", ApplicationInfo.Title);
                        var response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                            return JsonConvert.DeserializeObject<Release>(await response.Content.ReadAsStringAsync()); ;
                    }
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
}

namespace GitHub
{
    internal class Release
    {
        public Release()
        {
            Assets = new HashSet<Asset>();
        }

        [JsonProperty("tarball_url")]
        public string TarballUrl { get; set; }

        //[JsonProperty("author")]
        //public Author Author { get; set; }

        [JsonProperty("published_at")]
        public DateTimeOffset? PublishedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("prerelease")]
        public bool Prerelease { get; set; }

        [JsonProperty("draft")]
        public bool Draft { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("target_commitish")]
        public string TargetCommitish { get; set; }

        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }

        [JsonProperty("assets_url")]
        public string AssetsUrl { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("zipball_url")]
        public string ZipballUrl { get; set; }

        [JsonProperty("assets")]
        public ICollection<Asset> Assets { get; set; }
    }

    internal class Asset
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("download_count")]
        public int DownloadCount { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("browser_download_url")]
        public string BrowserDownloadUrl { get; set; }

        //[JsonProperty("uploader")]
        //public Author Uploader { get; set; }
    }
}