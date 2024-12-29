using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AxisAndAlliesCheater
{
    public partial class Form1 : Form
    {
        private string OriginalText = "";

        private string OriginalFileName = "";
        private string OriginalPrettyFileName = "";
        private string MyNewFileName = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            var appdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var directoryToUse = appdataFolder;

            var axisAndAlliesDirectory = Path.Combine(appdataFolder, "axisandalliesonline-desktop");
            if (Directory.Exists(axisAndAlliesDirectory))
            {
                directoryToUse = axisAndAlliesDirectory;

                var gamesDirectory = Path.Combine(axisAndAlliesDirectory, "local-games");

                if (Directory.Exists(gamesDirectory))
                {
                    directoryToUse = gamesDirectory;
                }
            }

            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            openFileDialog1.InitialDirectory = directoryToUse;

            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                OriginalFileName = openFileDialog1.FileName;
                ChosenFileTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void ReadFileButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please make sure Axis and Allies is closed before continuing");
            
            // create temporary file
            var originalText = File.ReadAllText(OriginalFileName);
            var file = openFileDialog1.FileName;

            OriginalPrettyFileName = Path.GetFileNameWithoutExtension(OriginalFileName) + "_original" + Path.GetExtension(OriginalFileName);

            // write out the original data
            File.WriteAllText(OriginalPrettyFileName, originalText);

            OriginalFormattedFileTextBox.Text = OriginalPrettyFileName;

            MessageBox.Show("Open the copied file in visual studio code and auto format it.");

            var debugExe = this.GetType().Assembly.Location;
            var debugFolder = Path.GetDirectoryName(debugExe);
            OpenFolderToPath(debugFolder);

            
        }

        private void OpenFolderToPath(string folderToOpen)
        {
            try
            {
                Process.Start(folderToOpen);
            }
            catch { }
        }

        private void MakeCopyButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Make sure your code is pretty json formatted before you continue.", "Is your code formatted?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result != DialogResult.OK)
            {
                // we haven't formatted thje file
                return;
            }
            var originalText = File.ReadAllText(OriginalPrettyFileName);

            MyNewFileName = Path.GetFileNameWithoutExtension(OriginalFileName) + "_temp" + Path.GetExtension(OriginalFileName);

            // write out the one we will update, this will help with the diff
            File.WriteAllText(MyNewFileName, originalText);
            MyNameFileTextBox.Text = MyNewFileName;
        }

        private void StartChangesButton_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines(MyNewFileName);
            Dictionary<string, bool> powersToHelp = new Dictionary<string, bool>();
            foreach (string line in lines)
            {
                if (line.Contains("\"power\":"))
                {
                    var powerName = GetPowerNameFromLine(line);
                    if (!powersToHelp.ContainsKey(powerName))
                    {
                        var result = MessageBox.Show($"Do you want to help this country: {powerName}?", $"Help {powerName}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            powersToHelp.Add(powerName, true);
                        }
                        else
                        {
                            powersToHelp.Add(powerName, false);
                        }
                    }
                }
            }

            List<string> newLines = lines.ToList();
            newLines = ModifyLines(newLines, "bankedIPCs", "15000", powersToHelp);
            newLines = ModifyLines(newLines, "hasIC", "true", powersToHelp); 
            newLines = ModifyLines(newLines, "ipcValue", "20", powersToHelp);

            File.WriteAllLines(MyNewFileName, newLines);

            MessageBox.Show($"Updated file has been written to {MyNewFileName}. Verify the contents in WinMerge or other diff tool before overwriting");
        }

        private List<string> ModifyLines(List<string> lines, string searchValue, string desiredValue, Dictionary<string, bool> powersToHelp)
        {
            List<string> newLines = new List<string>();
            int currentLineNumber = 0;
            foreach (string originalLine in lines)
            {
                if (originalLine.Contains($"\"{searchValue}\":"))
                {
                    bool doWeModify = DoWeWantToHelp(lines, currentLineNumber, powersToHelp);
                    if(doWeModify)
                    {
                        var myNewLine = $"\"{searchValue}\": {desiredValue},";
                        var whiteSpaceCount = originalLine.Length - myNewLine.Length;

                        // add the same amount of white space back
                        while(myNewLine.Length < originalLine.Length)
                        {
                            myNewLine = " " + myNewLine;
                        }
                        newLines.Add(myNewLine);
                    }
                    else
                    {
                        newLines.Add(originalLine);
                    }
                }
                else
                {
                    newLines.Add(originalLine);
                }
                currentLineNumber++;
            }

            return newLines;
        }

        private bool DoWeWantToHelp(List<string> lines, int currentLineNumber, Dictionary<string, bool> powersToHelp)
        {

            for (int i = currentLineNumber; i >= 0; i--)
            {
                foreach (var power in powersToHelp.Keys)
                {
                    var currentLine = lines[i];
                    
                    // no owner - don't modify
                    if(currentLine.Contains("owner") && currentLine.Contains("null"))
                    {
                        return false;
                    }

                    if (currentLine.Contains(power))
                    {
                        return powersToHelp[power];
                    }
                }
            }

            // we couldn't find the power don't modify
            return false;
            //throw new ArgumentOutOfRangeException("Could not find power to modify")
        }

        private string GetPowerNameFromLine(string line)
        {
            var returnLine = line.Replace("power", "");
            Regex rgx = new Regex("[^a-zA-Z_0-9 -]");
            returnLine = rgx.Replace(returnLine, "");
            returnLine = returnLine.Trim();
            return returnLine;
        }

        private void OverwriteOriginalButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to override the contents of {OriginalFileName} with the contents of {MyNewFileName}?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                var newText = File.ReadAllText(MyNewFileName);
                string replacement = Regex.Replace(newText, @"\t|\n|\r", "");
                File.WriteAllText(OriginalFileName, replacement);
                MessageBox.Show("Changes complete");
            }
        }
    }
}
