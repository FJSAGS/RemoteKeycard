using Exiled.API.Interfaces;


namespace ClassLibrary3
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
    }
}
