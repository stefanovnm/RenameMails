using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace RenameMails
{
    public static class OrganizeMails
    {
        public static void MoveFiles()
        {
            var attachmentFiles = GetAttachments();
            var fileName = GetMainMailFile();
            if (fileName == string.Empty)
            {
                MessageBox.Show("There are no mail with valid structure!");
                return;
            }

            if (attachmentFiles.Count > 0)
            {
                var directory = CreateDirectory();
                var oldDirectory = ReturnDirectoryName(directory);

                foreach (var attachment in attachmentFiles)
                {
                    var oldFile = oldDirectory + "\\" + ReturnFileNameFromDirectoryName(attachment);
                    var newFile = directory + "\\" + ReturnFileNameFromDirectoryName(attachment);
                    File.Move(oldFile, newFile);
                }
            }

            var newFileName = ReturnNewMailName(fileName);

            Dictionary<string, string> forReplace = SplitByHashTag();

            foreach (KeyValuePair<string, string> item in forReplace)
            {
                newFileName = newFileName.Replace(item.Key, item.Value);
            }

            File.Move(fileName, newFileName);
            Execute.Finish();
        }

        public static string GetCurrentDay()
        {
            string date = string.Empty;

            DateTime today = DateTime.Today;

            date = today.ToString("yyyyMMdd");

            return date;
        }

        /// <summary>
        /// Replace all special characters in current filename
        /// </summary>
        /// <param name="file">file to rename</param>
        /// <param name="whitespace">if true - replace whitespaces else replace umlauts</param>
        public static string ReturnNewFilename(string file, bool whitespace)
        {
            Dictionary<string, string> letters = GetLettersToRename();

            string newfile = file;

            if (whitespace)
            {
                newfile = newfile.Replace(" ", "_");
                while (newfile.IndexOf("__") > 1)
                {
                    newfile = newfile.Replace("__", "_");
                }
                newfile = newfile.Replace("_-_", "-");
                newfile = newfile.Replace("-_", "-");
                newfile = newfile.Replace("_-", "-");
            }
            else
            {
                foreach (KeyValuePair<string, string> letter in letters)
                {
                    newfile = newfile.Replace(letter.Key, letter.Value);
                }
            }

            return newfile;
        }

        public static List<string> GetAllFiles()
        {
            var location = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(location);

            List<string> allFiles = new List<string>();

            foreach (var file in files)
            {
                var fileLength = file.Length;

                var isExeFile = file.Substring(fileLength - 4, 4) == ".exe";
                if (!isExeFile)
                {
                    allFiles.Add(file);
                }
            }

            return allFiles;
        }

        public static void RenameFiles(bool whitespace)
        {
            List<string> filesToRename = new List<string>();
            var files = GetAllFiles();
            foreach (var file in files)
            {
                var newFilename = ReturnNewFilename(file, whitespace);
                if (file != newFilename)
                {
                    File.Move(file, newFilename);
                }
            }
        }

        private static Dictionary<string, string> SplitByHashTag()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            StreamReader file = new StreamReader("H:\\Admin\\mails.txt");

            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                var index = line.IndexOf('#');
                var length = line.Length;
                var wordForSearch = line.Substring(0, index);
                var wordForReplace = line.Substring(index + 1, length - index - 1);
                result.Add(wordForSearch, wordForReplace);
            }

            file.Close();
            return result;
        }

        private static string ReturnNewMailName(string file)
        {
            var mainFile = GetMainMailFile();

            var directory = ReturnDirectoryName(mainFile);
            var mainFileName = ReturnFileNameFromDirectoryName(mainFile);
            var mainFileNameLength = mainFileName.Length;

            mainFile = directory + "\\" + mainFileName.Substring(0, 14) + "E-" + mainFileName.Substring(14, mainFileNameLength - 14);

            return mainFile;
        }

        private static string CreateDirectory()
        {
            string file = GetMainMailFile();

            string directory = string.Empty;

            var fileName = ReturnFileNameFromDirectoryName(file);
            var directoryName = ReturnDirectoryName(file);
            int fileNameLength = fileName.Length;

            directory = directoryName + "\\";

            directory += fileName.Substring(0, 14) + "A-" + fileName.Substring(14, fileNameLength - 18);

            Dictionary<string, string> forReplace = SplitByHashTag();

            foreach (KeyValuePair<string, string> item in forReplace)
            {
                directory = directory.Replace(item.Key, item.Value);
            }

            DirectoryInfo di = Directory.CreateDirectory(directory);

            return directory;
        }

        private static string GetMainMailFile()
        {
            string mainFile = string.Empty;
            string today = GetCurrentDay();

            var files = GetAllFiles();

            foreach (var file in files)
            {
                var fileName = ReturnFileNameFromDirectoryName(file);
                if (fileName.Length > 8)
                {
                    string dateString = fileName.Substring(0, 8);
                    string format = "yyyyMMdd";
                    DateTime dateTime;
                    if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                    {
                        // MessageBox.Show(dateTime.ToString());
                        mainFile = file;
                        break;
                    }
                    
                    // if (fileName.Substring(0, 8) == today)
                    // {
                    //     mainFile = file;
                    //     break;
                    // }
                }
            }

            return mainFile;
        }

        private static List<string> GetAttachments()
        {
            var list = new List<string>();

            var mainFile = GetMainMailFile();

            var allFiles = GetAllFiles();

            foreach (string file in allFiles)
            {
                if (file != mainFile)
                {
                    list.Add(file);
                }
            }

            return list;
        }

        private static string ReturnFileNameFromDirectoryName(string file)
        {
            var fileLength = file.Length;
            var lastIndexOfSlash = file.LastIndexOf('\\');

            var fileName = file.Substring(lastIndexOfSlash + 1, fileLength - lastIndexOfSlash - 1);

            return fileName;
        }

        private static string ReturnDirectoryName(string file)
        {
            var fileLength = file.Length;
            var lastIndexOfSlash = file.LastIndexOf('\\');

            var directory = file.Substring(0, lastIndexOfSlash);

            return directory;
        }

        private static Dictionary<string, string> GetLettersToRename()
        {
            Dictionary<string, string> valuesToRename = new Dictionary<string, string>();

            valuesToRename.Add("ö", "oe");
            valuesToRename.Add("ä", "ae");
            valuesToRename.Add("ü", "ue");
            valuesToRename.Add("ß", "ss");
            valuesToRename.Add("Ö", "Oe");
            valuesToRename.Add("Ä", "Ae");
            valuesToRename.Add("Ü", "Ue");

            valuesToRename.Add("Ą", "A");
            valuesToRename.Add("Ć", "C");
            valuesToRename.Add("Ę", "E");
            valuesToRename.Add("Ł", "L");
            valuesToRename.Add("Ń", "N");
            valuesToRename.Add("Ó", "O");
            valuesToRename.Add("Ś", "S");
            valuesToRename.Add("Ź", "Z");
            valuesToRename.Add("Ż", "Z");
            valuesToRename.Add("ą", "a");
            valuesToRename.Add("ć", "c");
            valuesToRename.Add("ę", "e");
            valuesToRename.Add("ł", "l");
            valuesToRename.Add("ń", "n");
            valuesToRename.Add("ó", "o");
            valuesToRename.Add("ś", "s");
            valuesToRename.Add("ź", "z");
            valuesToRename.Add("ż", "z");

            return valuesToRename;
        }
    }
}
