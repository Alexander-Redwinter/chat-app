namespace Cornerstone
{
    public class FrameworkEnvironment
    {
        public bool IsDevelopment { get; set; } = true;

        public string Configuration => IsDevelopment ? "Development" : "Production";

        public FrameworkEnvironment()
        {

#if RELEASE
            IsDevelopment = false;
#endif

        }

    }
}
