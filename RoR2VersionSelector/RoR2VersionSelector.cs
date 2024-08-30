using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoR2VersionSelector
{
    public partial class RoR2VersionSelector : Form
    {
        private Process DepotDownloaderProcess;

        private string[] AllRoR2VersionsStringSorted;

        private long ManifestId = 0;
        private string ManifestArg = "";

        private string DepotDownloaderArgs = "";

        private string OutputFolderPathArg = "";

        private string FileListArg = "";

        public RoR2VersionSelector()
        {
            InitializeComponent();
        }

        private static string GetDepotsFolder() =>
            Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "depots"));

        private bool IsValidDownloadedDepot(string folderName)
        {
            if (!Directory.Exists(folderName))
            {
                return false;
            }

            foreach (var filePath in Directory.EnumerateFiles(folderName, "Risk of Rain 2.exe", SearchOption.AllDirectories))
            {
                return true;
            }

            return false;
        }

        private List<string> GetRiskofRain2Folders(string rootPath)
        {
            var res = new List<string>();

            if (!Directory.Exists(rootPath))
            {
                return res;
            }

            foreach (var filePath in Directory.EnumerateFiles(rootPath, "Risk of Rain 2.exe", SearchOption.AllDirectories))
            {
                res.Add(Path.GetDirectoryName(filePath));
            }

            return res;
        }

        private static string TextBoxDepotDownloadResultDefaultText => "Download the version of your choice through the interface above." +
                Environment.NewLine +
                "You may need to enter a Steam Guard code for DepotDownloader to download the version correctly." +
                Environment.NewLine +
                "Once manifest depot download has reached 100%:" +
                Environment.NewLine +
                "If you wish to use this version via Steam / r2modman / Thunderstore Mod Manager:" +
                Environment.NewLine +
                "Press the Copy Downloaded Version To Steam Install button," +
                Environment.NewLine +
                "A File dialog box will then open, allowing you to select the folder to which the ror2 version just downloaded is to be copied." +
                Environment.NewLine +
                "Otherwise, you can find the downloaded depots here: " + GetDepotsFolder();

        private void RoR2VersionSelector_Load(object sender, EventArgs e)
        {
            AllRoR2VersionsStringSorted = Enum.GetNames(typeof(RoR2Versions));
            Array.Sort(AllRoR2VersionsStringSorted);
            ComboBoxVersionSelector.DataSource = AllRoR2VersionsStringSorted;

            TextBoxDepotDownloaderResult.ReadOnly = true;

            UpdateInitialState();
        }

        private async void ButtonDownloadDepot_Click(object sender, EventArgs e)
        {
            ButtonDownloadDepot.Enabled = false;

            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = DepotDownloaderArgs,
                UseShellExecute = true
            };

            try
            {
                DepotDownloaderProcess = new Process { StartInfo = startInfo };

                DepotDownloaderProcess.Start();

                DepotDownloaderProcess.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                ButtonDownloadDepot.Enabled = true;
            }
        }

        private void UpdateDepotDownloaderArgs()
        {
            DepotDownloaderArgs = $"/k \".\\DepotDownloader.exe " +
                            $"-app 632360 " +
                            $"-depot 632361 " +
                            $"{ManifestArg} " +
                            $"-username {TextBoxUsername.Text} " +
                            $"{FileListArg} " +
                            $"-dir \"{OutputFolderPathArg}\"\"";

            TextBoxDepotDownloaderResult.Text = TextBoxDepotDownloadResultDefaultText;
            TextBoxDepotDownloaderResult.Text += Environment.NewLine;
            TextBoxDepotDownloaderResult.Text += Environment.NewLine;
            TextBoxDepotDownloaderResult.Text += "Args used for DepotDownloader:";
            TextBoxDepotDownloaderResult.Text += Environment.NewLine;
            TextBoxDepotDownloaderResult.Text += DepotDownloaderArgs;
        }

        private void SetManifestIdAndArgAndOuputFolderPathArg()
        {
            var allRoR2VersionsStringNotSorted = Enum.GetNames(typeof(RoR2Versions));
            var ror2Versions = (RoR2Versions[])Enum.GetValues(typeof(RoR2Versions));
            for (var i = 0; i < AllRoR2VersionsStringSorted.Length; i++)
            {
                if (allRoR2VersionsStringNotSorted[i] == AllRoR2VersionsStringSorted[ComboBoxVersionSelector.SelectedIndex])
                {
                    ManifestId = (long)ror2Versions[i];
                }
            }

            ManifestArg = ManifestId != -1 ? $" -manifest {ManifestId} " : " ";

            OutputFolderPathArg = Path.Combine(GetDepotsFolder(), AllRoR2VersionsStringSorted[ComboBoxVersionSelector.SelectedIndex]);
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            foreach (var dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            foreach (var newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        private void ButtonCopyDownloadedVersionToSteamInstall_Click(object sender, EventArgs e)
        {
            var sourceFolders = GetRiskofRain2Folders(GetDepotsFolder());
            if (sourceFolders.Count <= 0)
            {
                MessageBox.Show("No depots available to copy.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var fileDialog = new FileSelectionDialog(sourceFolders);
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using var openFileDialog = new OpenFileDialog();
            // Set to filter out all files, but allow folder selection
            openFileDialog.Filter = "Folders|*.none";
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;
            openFileDialog.FileName = "Risk of Rain 2 Folder";

            openFileDialog.Title = "Select the destination folder where the depot will be copied to.";

            const string defaultSteamRoR2InstallFolderPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Risk of Rain 2";
            if (Directory.Exists(defaultSteamRoR2InstallFolderPath))
            {
                openFileDialog.InitialDirectory = defaultSteamRoR2InstallFolderPath;
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var selectedFolderPath = Path.GetDirectoryName(openFileDialog.FileName);

                // Get the selected file path
                string selectedFilePath = fileDialog.SelectedFilePath;

                // Prompt the user for confirmation
                var result = MessageBox.Show(
                    $"Do you want to copy the downloaded RoR2 Version from\n\n{selectedFilePath}\n\nto\n\n{selectedFolderPath}",
                    "Confirm Folder Copy",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    var destinationFolder = selectedFolderPath;

                    try
                    {
                        CopyFilesRecursively(selectedFilePath, destinationFolder);

                        MessageBox.Show("Folder copied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error copying folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Folder copy operation canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No destination folder selected.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateInitialState()
        {
            SetManifestIdAndArgAndOuputFolderPathArg();

            SetFileListArg();

            UpdateDepotDownloaderArgs();
        }

        private void ComboBoxVersionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetManifestIdAndArgAndOuputFolderPathArg();

            UpdateDepotDownloaderArgs();
        }

        private void CheckBoxDownloadOnlyDLLFiles_CheckedChanged(object sender, EventArgs e)
        {
            SetFileListArg();

            UpdateDepotDownloaderArgs();
        }

        private void SetFileListArg()
        {
            FileListArg = " ";
            if (CheckBoxDownloadOnlyDLLFiles.Checked)
            {
                var dllOnlyFilePath = "dllonly.txt";
                FileListArg = $" -filelist {dllOnlyFilePath} ";

                if (!File.Exists(dllOnlyFilePath))
                {
                    File.WriteAllText(dllOnlyFilePath, @"regex:.*\.dll$");
                }
            }
        }

        private void TextBoxUsername_TextChanged(object sender, EventArgs e)
        {
            UpdateDepotDownloaderArgs();
        }
    }
}
