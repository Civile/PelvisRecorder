using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TXRXText
{
    class VersionChecker
    {


        /// <summary>
        /// Async - check for new versions
        /// </summary>
        /// <param name="WebHook"></param>
        public static void Check(CaptainHook WebHook)
        {

            if (WebHook == null)
                return;

            var Delegate = new Delegate_CheckNewVersion(CheckForNewVersions);
            Delegate.BeginInvoke(WebHook, null, null);
        }




        /// <summary>
        /// Requests info about a new version
        /// </summary>
        /// <param name="WebHook"></param>
        delegate void Delegate_CheckNewVersion(CaptainHook WebHook);
        public static void CheckForNewVersions(CaptainHook WebHook)
        {
            string Response = String.Empty;

            WebHook.HookRequest(@"http://projects.edoardocasella.it/pelvisrecorder/pelvisservice.php?scanVersion=1&connectedPart=application");

            if((Response = WebHook.HookResponse()) != String.Empty)
            {
                dynamic JSONResponse = JsonConvert.DeserializeObject(Response);

                if (JSONResponse != null)
                {
                    string AppVersion     = Convert.ToString(JSONResponse.Version).Trim();
                    string AppDescription = Convert.ToString(JSONResponse.Description).Trim().Replace("rar", "").Replace("zip", "");

                    if(VersionChecker.CompareVersions(Form1.Version, AppVersion) == -1)
                    {

                        /*
                         1)Major release number
                         2)Minor release number
                         3)Maintenance release number (bugfixes only)
                         4)If used at all: build number (or source control revision number)
                         */

                        DialogResult dr = MessageBox.Show("New version available -> " + AppVersion + "\n------------------------------------------------------------------------\nWhat changes:\n" + AppDescription + "\n\n\nYou want to download it now?", "PelvisRecorder - New version available", MessageBoxButtons.YesNo);

                        switch (dr)
                        {
                            case DialogResult.No: break;
                            case DialogResult.Yes: System.Diagnostics.Process.Start("http://projects.edoardocasella.it/pelvisrecorder"); break;
                        }
                        
                    }
                }
            }

        }



        /// <summary>
        /// Compare two versions
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>-1 if v1 > v2 || or 1 if v1 < v2</returns>
        private static int CompareVersions(string v1, string v2)
        {
            v1 = v1.Replace(".", "");
            v2 = v2.Replace(".", "");
            
            int nv1 = Convert.ToInt32( v1 );
            int nv2 = Convert.ToInt32( v2 );
            
            
            if(nv1 < nv2)
                return -1;
            else
                return 1;
            
        }


    }
}
