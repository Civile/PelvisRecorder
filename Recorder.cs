using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Lame;
using NAudio.Wave;
using NAudio.Mixer;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;



/// <summary>
/// Enum OutputFormat
/// </summary>
public enum OutputFormat
{
    MP3 = 1,
    WAV = 2
}



namespace TXRXText
{

    class Recorder
    {
        /*Booleans*/
        protected bool _Ready;
        protected bool _Recording;
        protected bool _Debug;
        public bool    RecordSilence;
        public bool    Paused;

        /*Audio properties*/
        protected int _Hertz;
        protected int _BitRate;

        protected OutputFormat _RecordingFormat;

        protected string _DestinationFileName;
        protected string _DestinationRoot;
        protected string _DestinationPath;

        /*Handler*/
        protected LameMP3FileWriter _MP3Writer;
        protected WaveFileWriter    _WAVWriter;
        protected MixerController MixerControl;

        protected IWaveIn _Capturer;

        



        //Constructor
        public Recorder()
        {
            this._Ready         = false;
            this._Recording     = false;
            this._Debug         = false;
            this.RecordSilence  = false;
            this.Paused         = false;

            this._Hertz     = 0; //auto
            this._BitRate   = 128;
          
            this._MP3Writer = null;
            this._WAVWriter = null;
            this._Capturer  = null;

            this._RecordingFormat = OutputFormat.WAV;

            this._DestinationFileName = String.Empty;
            this._DestinationRoot     = String.Empty;
        }



        protected bool StartCapturer()
        {
            try
            {
                _Capturer = new WasapiLoopbackCapture();
            }
            catch (ExternalException e)
            {
                return false;
            }

            return true;
        }





        protected bool StartWriter(string filePath, WaveFormat waveformat)
        {

            if (Common.CanWriteOnFile(filePath))
            {
                //MP3
                if (this._RecordingFormat == OutputFormat.MP3)
                {
                    try
                    {
                        this._MP3Writer = new LameMP3FileWriter(filePath, waveformat, this._BitRate);
                    }
                    catch(ExternalException e)
                    {
                        MessageBox.Show(e.Message);
                        return false;
                    }
                        
                }
                //WAV
                else if(this._RecordingFormat == OutputFormat.WAV)
                {
                    this._WAVWriter = new WaveFileWriter(filePath, this._Capturer.WaveFormat);
                }

                return true;
            }
            else
            {
                return false;
            }
            
        }


    


        /*
         * Check if a byte's array contains silence data
         */
        protected bool IsSilenceData(byte[] data)
        {
            return (data[0] + data[1] + data[2] + data[3] + data[4] + data[5] + data[6] + data[7]) == 0;
        }



        //Dispose MP3/WAV Writer
        protected void DisposeWriter()
        {
            switch(this._RecordingFormat)
            {
                case OutputFormat.MP3:
                    if (_MP3Writer == null)
                        return;

                    _MP3Writer.Flush();
                    _MP3Writer.Dispose();
                    _MP3Writer = null;
                    break;

                case OutputFormat.WAV:
                     if (_WAVWriter == null)
                        return;

                    _WAVWriter.Flush();
                    _WAVWriter.Dispose();
                    _WAVWriter = null;
                    break;
            }
        }




        /*Stop recording and save buffer*/
        public void StopAndSave()
        {
            if (this._Capturer == null)
                return;
            else
            {
                _Capturer.StopRecording();
                
                _Capturer.Dispose();
                this.DisposeWriter();
                _Capturer = null;
                
                this._Recording = false;
                this.Paused     = false;
            }
        }




        /*Write sound buffer*/
        public void WriteSoundData(object s, WaveInEventArgs capData)
        {
            //save the recorded audio
            if (this.RecordingFormat == OutputFormat.MP3)
            {
                if (_MP3Writer != null)
                    _MP3Writer.Write(capData.Buffer, 0, capData.BytesRecorded);
            }
            else
            {
                if (_WAVWriter != null)
                    _WAVWriter.Write(capData.Buffer, 0, capData.BytesRecorded);
            }
        }



        /*
        ====================================
        PUBLIC
        ====================================
        */
        
        //Return the format (string extension) relative to the OutputFormat "int" value
        public string EnumToFormatName(OutputFormat formatEnum)
        {
            if (formatEnum == OutputFormat.MP3)
                return "mp3";
            else if (formatEnum == OutputFormat.WAV)
                return "wav";

            return String.Empty;
        }
        
        public bool Ready
        {
            get { return this._Ready; }
            set { this._Ready = value; }
        }

        public bool Recording
        {
            get { return this._Recording; }
        }


        public int Hertz
        {
            get { return this._Hertz; }
            set { if (!this.Recording) this._Hertz = value; }
        }


        public int BitRate
        {
            get { return this._BitRate; }
            set { if (!this.Recording) this._BitRate = value; }
        }


        public string DestinationFileName
        {
            get { return this._DestinationFileName;  }
            set { this._DestinationFileName = value; }
        }


        public OutputFormat RecordingFormat
        {
            get { return this._RecordingFormat; }
            set { this._RecordingFormat = value; }
        }


        public string CompleteDestination
        {
            get { return String.Concat(this._DestinationPath, @"\" , this._DestinationFileName, ".", this.EnumToFormatName(this._RecordingFormat)); }
        }

        /*
        ====================================
        OVERRIDE
        ====================================
        */
        

    }
}
