using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;

namespace WebApiContrib.Logging.Raygun
{
    //source: https://github.com/phillip-haydon/Nancy.Raygun
    public class WebApiRaygunEnvironmentMessage
    {
        private List<double> _diskSpaceFree = new List<double>();

        public WebApiRaygunEnvironmentMessage()
        {
            ProcessorCount = Environment.ProcessorCount;
            Locale = CultureInfo.CurrentCulture.DisplayName;
            var now = DateTime.Now;
            UtcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(now).TotalHours;
            OSVersion = Environment.OSVersion.VersionString;

            try
            {
                Architecture = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
                GetDiskSpace();
            }
            catch (SecurityException)
            {
                System.Diagnostics.Trace.WriteLine("RaygunClient error: couldn't access environment variables. If you are running in Medium Trust, in web.config in RaygunSettings set mediumtrust=\"true\"");
            }
        }

        private void GetDiskSpace()
        {
            foreach (var drive in DriveInfo.GetDrives().Where(drive => drive.IsReady))
            {
                DiskSpaceFree.Add((double)drive.AvailableFreeSpace / 0x40000000); // in GB
            }
        }

        public int ProcessorCount { get; private set; }
        public string OSVersion { get; private set; }
        public string Architecture { get; private set; }
        public string Locale { get; private set; }
        public double UtcOffset { get; private set; }

        public List<double> DiskSpaceFree
        {
            get
            {
                return _diskSpaceFree;
            }
            set { _diskSpaceFree = value; }
        }
    }
}