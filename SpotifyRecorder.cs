using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using CSCore;
using CSCore.SoundOut;
using CSCore.Codecs;
using CSCore.Streams;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Threading;
using System.Web;
using System.Net;

using NAudio.Lame;
using NAudio.Wave;
using NAudio.Mixer;

using System.Windows;
using System.Diagnostics;
using System.Drawing;

using System.ComponentModel;



namespace TXRXText
{
    class SpotifyRecorder : Recorder
    {
        
        /*Strings*/
        private string SpotifyFolderName  = "Spotify";
        private string SpotifyProcessName = "spotify";

        /*Handlers*/
        private string _wNameOutput;

        /*Booleans*/
        public  bool SubdivideByArtist    = true;
        private bool _SingleTrackRecoring = false;
        private bool _MutesProcesses      = false;
        public  bool  SkipTrack           = false;

        /*Handlers*/
        private DrunkenXMLSailor XMLSailor;
        private CaptainHook      WebHook;


        /*Destination directory*/
        private string     Spotify_LastTitleRecorded;
        private Control    TXT_Display;
        private Control    LBL_Duration;
        private PictureBox PBOX_Cover;

        /*LastFMService*/
        private LASTFMService LastFMService;



        /*Constructor*/
        public SpotifyRecorder(string targetRoot, Control TXT_Display, Control LBL_Duration, PictureBox PBOX_Cover) : base()
        {
            //Create destination root (if not exists)
            string SpotifyRoot = String.Concat(targetRoot, @"\", this.SpotifyFolderName);
            if (!Common.FolderExists(SpotifyRoot))
                Common.CreateFolder(SpotifyRoot);

            //Set destination root
            this._DestinationRoot = SpotifyRoot;
            
            //Init properties
            this.TXT_Display   = TXT_Display;
            this.LBL_Duration  = LBL_Duration;
            this.PBOX_Cover    = PBOX_Cover;

            /*Setup application*/
            this.__Setup();

        }



        public bool SingleTrackRecording
        {
            get { return this._SingleTrackRecoring; }
            set { this._SingleTrackRecoring = value; }
        }



        public bool MutesProcesses
        {
            get { return this._MutesProcesses; }
            set 
            { 
                this._MutesProcesses = value;
                this.MixerControl.MuteProcess("wmplayer");
            }
        }






        /// <summary>
        /// SetupApplication
        /// </summary>
        private void __Setup()
        {

            this._wNameOutput = String.Empty;

            this.XMLSailor      = null;
            this.WebHook        = new CaptainHook();
            this.LastFMService  = new LASTFMService();
            this.MixerControl   = new MixerController();

            this.Spotify_LastTitleRecorded = String.Empty;

        }





        
        /// <summary>
        /// StartRecording
        /// </summary>
        /// <returns></returns>
        public int StartRecording() 
        {
            //if (!Common.LookForProcess_Bool(this.SpotifyProcessName))
              //  return -1;

            /*Get destination file name - audio track artist and title*/
            this.DestinationFileName = Common.Spotify_GetTrackName();

            if (!base.StartCapturer())
                return 0;

            try
            {
                /*Start recording thread*/
                new Thread(delegate() { 
                    this.__StartRecordingThread(_Capturer); 
                }).Start();

            }
            catch(ExternalException e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally
            {
                _Capturer.DataAvailable += this.__AudioDataAvailable;
            }

            return 1;
            
        }







        /// <summary>
        /// CREATE DESTINATIO WRITER
        /// </summary>
        /// <param name="DestFName"></param>
        public bool CreateDestinationWriter(string DestFName) 
        {
            /*Save destionation file name*/
            if (!this._SetDestinationFileName(DestFName))
                return false;

            int CurrentDeviceIndex = 0;

            /*Auto frequency*/
            if (this._Hertz == 0)
                this._Hertz = this._Capturer.WaveFormat.SampleRate;

            /*Select channels FIX*/
            int Channels = NAudio.Wave.WaveIn.GetCapabilities(CurrentDeviceIndex).Channels;

            if(!base.StartWriter(this._wNameOutput, NAudio.Wave.WaveFormatExtensible.CreateIeeeFloatWaveFormat(this._Hertz, Channels)))
            {
                this._AbortThread();
                this.WriteToDisplay("ABORTED: destination file is being used by another process");
                return false;
            }
   
            return true;

        }




        private void _AbortThread()
        {
            this._Capturer.DataAvailable -= this.__AudioDataAvailable;
            this._Recording = false;
        }




        /// <summary>
        /// _SetDestinationFileName
        /// </summary>
        /// <param name="DestFName"></param>
        private bool _SetDestinationFileName(string DestFName)
        {
            //Get the name output record file
            if (DestFName == String.Empty || DestFName == "")
                return false;

            //Clean _DestinationFileName (remove reserved characters)
            DestFName = Common.SanitizeFolderName(DestFName);

            this.DestinationFileName = String.Concat(DestFName, ".", base.EnumToFormatName(this._RecordingFormat));
            this._wNameOutput = String.Concat(this._DestinationRoot + @"\", DestFName, ".", base.EnumToFormatName(this._RecordingFormat));


            /*Subdivide by artist*/
            if(this.SubdivideByArtist)
            {
                string[] ArtistAndSong = this._DestinationFileName.Split(
                    new Char[] { '–' }
                );

                Common.CreateFolder( String.Concat(
                    this._DestinationRoot, @"\", ArtistAndSong[0].Trim(), @"\") 
                );

                this._wNameOutput = String.Concat(this._DestinationRoot, @"\", ArtistAndSong[0].Trim(), @"\", DestFName, ".", base.EnumToFormatName(this._RecordingFormat));
                

                /*Receive covers*/
                if(!ArtistAndSong[0].Contains("Spotify"))
                    LastFMService.LoadArtistPicture(ArtistAndSong[0], WebHook, XMLSailor, PBOX_Cover);

                this.WriteToDisplay("recording " + ArtistAndSong[0] + " - " + ArtistAndSong[1]);
            }

            return true;
        }
        





        /// <summary>
        /// RECORDING THREAD
        /// </summary>
        /// <param name="_Capturer"></param>
        private void __StartRecordingThread(IWaveIn _Capturer)
        {
            try
            {
                _Capturer.StartRecording();
            }
            catch(ExternalException e)
            {
                return;
            }

            //Recording
            this._Recording = true;
        }






        /// <summary>
        /// INTERNAL RECTHREAD
        /// </summary>
        /// <param name="s"></param>
        /// <param name="capData"></param>
        private void __AudioDataAvailable(object s, WaveInEventArgs capData)
        {
            /*Get current trackname-artist*/
            string TrackName = Common.Spotify_GetTrackName();
            //If paused or advertising time
            if ( this.Paused 
                || TrackName.Contains("Spotify")
                || TrackName == String.Empty)
                return;
            
            if(this.RecordingFormat == OutputFormat.MP3)
            {
                if (this._MP3Writer == null)
                    this.CreateDestinationWriter(TrackName);
            }
            else
            {
                if (this._WAVWriter == null)
                    this.CreateDestinationWriter(TrackName);
            }
             
            
            if(this.Spotify_LastTitleRecorded != String.Empty)
            {
                if (this.Spotify_LastTitleRecorded != TrackName && !this.SingleTrackRecording)
                {
                    //Dispose Writer and check for Advertising-Time
                    base.DisposeWriter();
                    
                    /*Jumps advertising*/
                    if (TrackName.Contains("Spotify"))
                        return;

                    if(!this.CreateDestinationWriter(TrackName))
                    {
                        return;
                    }

                    this.Spotify_LastTitleRecorded = String.Empty;
                    return;
                }
            }



            this.WriteSoundData(s, capData);

            
            if (this.Spotify_LastTitleRecorded == String.Empty)
                this.Spotify_LastTitleRecorded = TrackName;

            return;
        }






        /// <summary>
        /// SetTextCallback
        /// </summary>
        /// <param name="message"></param>
        public delegate void SetTextCallback(string message);

        public void WriteToDisplay(string text)
        {
            if(this.TXT_Display.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(WriteToDisplay);

                try
                {
                    this.TXT_Display.Invoke(d, new object[] { text });
                }
                catch(ObjectDisposedException e)
                {
                    return;
                }
            }
            else
            {
                this.TXT_Display.Text = text;
            }
        }







        public string GetLastRecordingPath()
        {
            return this._wNameOutput;
        }


    }
}
