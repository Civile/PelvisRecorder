using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TXRXText
{
    static class Common
    {

        /// <summary>
        /// GetSpotifyTrackName
        /// </summary>
        /// <returns></returns>
        public static string Spotify_GetTrackName()
        {

            Process process;
            if ((process = LookForProcess("spotify")) != null)
            {
                string SongTitle = process.MainWindowTitle/*.Replace("Spotify - ", "") not anymore from 1.0.2 spotify*/;

                /*If we are not playing any song*/
                string SongTitleWithoutSpaces = SongTitle.Replace(" ", String.Empty);

                if (SongTitleWithoutSpaces.Length != 0 && SongTitleWithoutSpaces != String.Empty)
                    return SongTitle;
            }
            
            return String.Empty;
        }




        /// <summary>
        /// Spotify_IsAdvertisingTime
        /// When advertising time: SpotifyMainWindowTitle is Spotify - spotify - spotify
        /// </summary>
        /// <returns></returns>
        public static bool Spotify_IsAdvertisingTime()
        {
            if(LookForProcess_Bool("spotify"))
            {
                string trackName = Common.Spotify_GetTrackName();

                int count = Common.CountStringOccurrences(trackName, "Spotify");
                if (count == 3)
                    return true;
            }

            return false;

        }


      


        /// <summary>
        /// Spotify_IsPaused
        /// </summary>
        /// <returns></returns>
        public static bool Spotify_IsPaused()
        {
            string Title = Common.Spotify_GetTrackName();
            Title = Title.Replace("Spotify", String.Empty).Replace(" ", String.Empty);

            if (Title.Length == 0)
            {
                return true;
            }

            return false;
           
        }



        /// <summary>
        /// CanWriteOnFile
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CanWriteOnFile(string path)
        {

            FileStream fs = null;

            try
            {
                fs = new FileStream(path, FileMode.Append);
            }
            catch (IOException ex)
            {
                return false;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return true;
        }


        
        /// <summary>
        /// LookForProcess
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static Process LookForProcess(string processName)
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    //TOFIX:: TUTTO LOWERCASE
                    if (process.ProcessName.ToLower() == processName.ToLower())
                    {
                        return process;
                    }
                    //Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                }
            }

            return null;
        }




        public static bool LookForProcess_Bool(string processName)
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (process.ProcessName.ToLower() == processName.ToLower())
                    {
                        return true;
                    }
                    //Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                }
            }

            return false;
        }



        /// <summary>
        /// OpenFolder
        /// </summary>
        /// <param name="path"></param>
        public static void OpenFolder(string path)
        {
            if (Directory.Exists(path))
            {
                Process.Start(path);
            }
        }



        /// <summary>
        /// CreateFolder
        /// </summary>
        public static void CreateFolder(string Path, bool OverWrite = false)
        {
            
            if (Path == String.Empty)
                return;
            
            if(Common.FolderExists(Path))
            {
                if (OverWrite)
                    Directory.CreateDirectory(Path);
                else
                {
                    return;
                }
            }
            
            Directory.CreateDirectory(Path);

        }


        /// <summary>
        /// FolderExists
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static bool FolderExists(string Path) 
        {
            return Directory.Exists(Path);
        }


        /// <summary>
        /// ClearPathName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ClearFolderName(string name)
        {
            char[] reserved = Path.GetInvalidFileNameChars();

            for (var i = 0; i < reserved.Length; i++)
                name = name.Replace(Convert.ToString(reserved[i]), "");

            return name;
        }



        /// <summary>
        /// CountStringOccurrences
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }



        public static string SanitizeFolderName(string name)
        {
            char[] reserved = Path.GetInvalidFileNameChars();

            for (var i = 0; i < reserved.Length; i++)
                name = name.Replace(Convert.ToString(reserved[i]), "");

            return name;
        }




        public static string GetEntireDateAsString()
        {
            string dateString = String.Empty;

            dateString = String.Concat(DateTime.Now.Year +
                    "-" + DateTime.Now.Month +
                    "-" + DateTime.Now.Day +
                    " " + DateTime.Now.Hour +
                    "-" + DateTime.Now.Minute +
                    "-" + DateTime.Now.Second);

            return dateString;
        }



        public static void RemoveFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

    }
}
