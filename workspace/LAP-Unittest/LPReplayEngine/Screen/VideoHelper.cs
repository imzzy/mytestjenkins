using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using OpenQA.Selenium;
using Microsoft.Expression.Encoder.ScreenCapture;
using System.Drawing;
using Microsoft.Expression.Encoder.Profiles;
using Microsoft.Expression.Encoder;
using System.IO;
using System.Reflection;


//from article http://learnseleniumtesting.com/recording-selenium-test-execution/
namespace ReplayEngine
{
    //TODO: configure this class to be configurations
    public static class AutomationLogging 
    {
        public static readonly string newLocationInResultFolder;

        static AutomationLogging()
        {
            newLocationInResultFolder = (new FileInfo(Assembly.GetExecutingAssembly().Location)).DirectoryName;
        }
    }
    public class VideoHelper
    {
        static ScreenCaptureJob _job;
        static bool _isRecording = true;

        //Call this method in setup method.   
        public static void StartRecordingVideo()
        {

            //Provide setting in config file if you want to do recording or not.
            if (_isRecording)
            {
                _job = new ScreenCaptureJob();

                //job.CaptureRectangle = Screen.PrimaryScreen.Bounds;
                _job.ShowFlashingBoundary = true;

                //provide the location where you want to save the recording.
                _job.OutputPath = AutomationLogging.newLocationInResultFolder;

                _job.Start();

            }

        }


        public static void StopRecordingVideo()
        {
            if (_isRecording)
            {
                string filename = _job.ScreenCaptureFileName;
                _job.Stop();
                //if (AutomationLogging.countOfError > 0)
                //{
                MediaItem src = new MediaItem(filename);
                Job jb = new Job();
                jb.MediaItems.Add(src);
                jb.ApplyPreset(Presets.VC1HD720pVBR);
                jb.OutputDirectory = AutomationLogging.newLocationInResultFolder;
                string output = ((Microsoft.Expression.Encoder.JobBase)(jb)).ActualOutputDirectory;
                jb.Encode();
                //}

                File.Delete(filename);
            }
        }
    }
}
