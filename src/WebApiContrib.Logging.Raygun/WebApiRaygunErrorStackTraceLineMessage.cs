namespace WebApiContrib.Logging.Raygun
{
    public class WebApiRaygunErrorStackTraceLineMessage
    {
        public int LineNumber { get; set; }

        public string ClassName { get; set; }

        public string FileName { get; set; }

        public string MethodName { get; set; }
    }
}