using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;



/*
==============================================================
PELVISRECORDER
 * Author: http://edoardocasella.it
 * 2014
==============================================================
*/


public enum Specialization
{
    SPOTIFY = 1,
    YOUTUBE = 2,
    NOTHING = 3
}



namespace TXRXText
{
    
    public partial class Form1 : Form
    {
        /*APP INFO*/
        private string APPNAME       = "PelvisRecorder";
        public static string Version = "1.2.7.0";

        private string[] DisturbingProcessess = { "Skype", "wmplayer", "thunderbird", "chrome", "firefox" };



        //Trasmettitore
        private SpotifyRecorder SpotifyRecorder;
        private CaptainHook WebHook;

        /*Folders - paths*/
        private string DestinationFolder = @"PelvisRecordings";
        private string ASSETS_PATH = @"assets\";


        /*Booleans*/
        private bool SpotifyIsActive = false;
        private bool NotifyToTaskbar = true;

        private Specialization Specialization;


        private string[] _Cache = 
        { 
            "notconfirmed", //hide from taskbar
            ""              //display-text before pause
        };





        public Form1()
        {
            /*Init components and setup application*/
            InitializeComponent();
            Setup();

            VersionChecker.Check(WebHook);
            
            /*GUI configuration*/
            MaximizeBox = false;
            BTN_OpenFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            CBOX_Hertz.SelectedIndex = 0;
            BTN_Rec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            


            /*Search for SPOTIFY*/
            Process Spotify;
            if ((Spotify = Common.LookForProcess("spotify")) != null)
            {
                this.AdviceAboutSpotify(true);
                this.SpotifyIsActive = true;
            }
            
        }


        private void Setup()
        {
            string DocPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string Destination = String.Concat(DocPath, @"\", this.DestinationFolder);

            if(!Directory.Exists(Destination))
            {
                Directory.CreateDirectory(Destination);
            }

            this.DestinationFolder = Destination;


            /*Application Exit event*/
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            /*SpotifyRecorder instance*/
            SpotifyRecorder = new SpotifyRecorder(this.DestinationFolder, this.TXT_Display, null, this.PBOX_Cover);
            /*WebHook*/
            WebHook = new CaptainHook();
            /*Specialization*/
            this.Specialization = Specialization.NOTHING;
        }



        



        /// <summary>
        /// OnApplicationExit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationExit(object sender, EventArgs e)
        {
            if(SpotifyRecorder.Recording)
                SpotifyRecorder.StopAndSave();
        }




        private void Record_Click(object sender, EventArgs e)
        {

            /*Search for SPOTIFY*/
            if(!this.SpotifyIsActive)
            {
                Process Spotify;
                if ((Spotify = Common.LookForProcess("spotify")) != null)
                {
                    this.AdviceAboutSpotify(true);
                    this.SpotifyIsActive = true;
                }
            }
            

            BTN_Rec.FlatAppearance.BorderColor = this.BackColor;
            
            if (!SpotifyRecorder.Recording)
            {
                /*Start recorder thread*/
                switch(SpotifyRecorder.StartRecording())
                {
                    case -1: MessageBox.Show("Sorry. I need Spotify! Remember that you must launch first Spotify and then PelvisRecorder."); return;
                    case  0: MessageBox.Show("Error while instantiating the internal Spotify recorder"); return;
                    case  1:
                        /*Update GUI controls*/
                        TXT_Display.Text = "Recording " + this.SpotifyRecorder.DestinationFileName;
                        Button_SetImageBG(BTN_Rec, this.ASSETS_PATH + "stoprecord.png");
                        radioButton1_BitRate128.Enabled = false;
                        radioButton1_BitRate190.Enabled = false;
                        radioButton1_BitRate320.Enabled = false;
                        CBOX_Hertz.Enabled              = false;
                        BTN_PauseRec.Visible            = true;
                        RAD_MP3.Enabled                 = false;
                        RAD_WAV.Enabled                 = false;
                        //BTN_SkipTrack.Visible           = true;
                        break;
                }
            }
            else
            {
                SpotifyRecorder.StopAndSave();
                TXT_Display.Text = "Stopped " + (SpotifyRecorder.DestinationFileName.Contains("Spotify") ? String.Empty : "and saved as " + SpotifyRecorder.DestinationFileName);
                /*Update GUI controls*/
                Button_SetImageBG(BTN_Rec, this.ASSETS_PATH + @"startrecord.png");
                BTN_PlayRecording.Enabled       = true;
                radioButton1_BitRate128.Enabled = true;
                radioButton1_BitRate190.Enabled = true;
                radioButton1_BitRate320.Enabled = true;
                CBOX_Hertz.Enabled              = true;
                BTN_PauseRec.Visible            = false;
                BTN_SkipTrack.Visible           = false;
                RAD_MP3.Enabled                 = true;
                RAD_WAV.Enabled                 = true;
                BTN_PauseRec.Text               = "pause rec";
            }
                
        }



        private void AdviceAboutSpotify(bool Spotify)
        {
            LBL_FoundSpotify.Visible = Spotify;
            RAD_SpotifySelect.Enabled = true;
            RAD_SpotifySelect.Checked = true;
        }



        private void Button_SetImageBG(Button control, string imgpath)
        {
            control.Image = Image.FromFile(imgpath);
        }


        private void LAB_AuthorLink_Click(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("http://projects.edoardocasella.it/pelvisrecorder");
        }


        private void CHK_RecordSilence_Change(object sender, EventArgs e)
        {
            SpotifyRecorder.RecordSilence = CHK_RecordSilence.Checked;
        }


        
        private void BTN_OpenFolder_Click(object sender, MouseEventArgs e)
        {
            Common.OpenFolder(this.DestinationFolder);
        }



        private void RAD_BitRate_Changed(object sender, EventArgs e)
        {
            RadioButton rb = (sender as RadioButton);

            switch (rb.Name)
            {
                case "radioButton1_BitRate320":
                    SpotifyRecorder.BitRate = 320;
                    break;
                case "radioButton1_BitRate190":
                    SpotifyRecorder.BitRate = 190;
                    break;
                case "radioButton1_BitRate128":
                    SpotifyRecorder.BitRate = 128;
                    break;
            }


        }


        private void CHK_SingleTrackRecording_Change(object sender, EventArgs e)
        {
            SpotifyRecorder.SingleTrackRecording = CHK_SingleTrackRecording.Checked;
        }



        private void BTN_PlayRecording_Click(object sender, EventArgs e)
        {
            
                
        }




        private void CBOX_Hertz_Changed(object sender, EventArgs e)
        {
            var thisCbox = (sender as ComboBox);
            string ListValue = thisCbox.Text.Replace("hz", "").Trim();
            if (ListValue == "auto")
                ListValue = "0";

            this.SpotifyRecorder.Hertz = Convert.ToInt32(ListValue);
        }


        private void RAD_AudioFormat_Changed(object sender, EventArgs e)
        {
            var thisRad = (sender as RadioButton);

            switch(thisRad.Name)
            {
                case "RAD_WAV":
                    SpotifyRecorder.RecordingFormat = OutputFormat.WAV;
                    break;
                case "RAD_MP3":
                    SpotifyRecorder.RecordingFormat = OutputFormat.MP3;
                break;
            }


        }

        private void CHK_MutesProcesses_Changed(object sender, EventArgs e)
        {
            SpotifyRecorder.MutesProcesses = (sender as CheckBox).Checked;
        }






        private void notifyIcon_Click(object sender, EventArgs e)
        {

            NotifyIcon notIcon = notifyIcon;
            Show();//shows the program on taskbar

            this.WindowState = FormWindowState.Normal;//undoes the minimized state of the form

            notIcon.Visible = false;//hides tray icon again
        }


        private void Window_OnResize(object sender, EventArgs e)
        {
            NotifyIcon notIcon = notifyIcon;

            if(this.NotifyToTaskbar == false)
                return;

            if (FormWindowState.Minimized == this.WindowState)
            {

                if (this._Cache[0] == "notconfirmed")
                {
                    DialogResult dr = MessageBox.Show("You want to hide the application from the taskbar? If you are recording Pelvis will continue.", "PelvisRecorder", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No)
                    {
                        this.NotifyToTaskbar = false;
                        return;
                    }
                    else
                    {
                        this.NotifyToTaskbar = true;
                    }

                    this._Cache[0] = "confirmed";
                }
                

                ShowInTaskbar = false;
                notIcon.Visible = true;

                string message = "PelvisRecorder is here";
                if (this.SpotifyRecorder.Recording)
                    message = String.Concat(message, " recording from Spotify");

                notIcon.BalloonTipText = message;
                notIcon.BalloonTipTitle = "PelvisRecorder";
                notIcon.Icon = this.Icon;

                notIcon.ShowBalloonTip(100);

                //Nasconde l'applicazione
                this.Hide();
            }
            else
            {
                notIcon.Visible = false;
                ShowInTaskbar = true;
                this.Show();
            }
        }




        private void BTN_PauseRec_Click(object sender, MouseEventArgs e)
        {
            this.SpotifyRecorder.Paused = !this.SpotifyRecorder.Paused;

            if(this.SpotifyRecorder.Paused)
            {
                this._Cache[1] = this.TXT_Display.Text;
                this.TXT_Display.Text = "Paused...";
                BTN_PauseRec.Text = "resume rec";
            }
            else
            {
                this.TXT_Display.Text = this._Cache[1];
                BTN_PauseRec.Text = "pause rec";
            }
        }




        private void BTN_SkipTrack_Clicked(object sender, MouseEventArgs e)
        {
            this.SpotifyRecorder.SkipTrack = !this.SpotifyRecorder.SkipTrack;
            if (this.SpotifyRecorder.SkipTrack)
                BTN_SkipTrack.FlatAppearance.BorderColor = Color.Tomato;
            else BTN_SkipTrack.FlatAppearance.BorderColor = Color.DarkGray;
        }

        private void TXT_Display_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
