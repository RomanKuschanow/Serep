using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace Serep.Uno.Skia.Tizen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new Serep.Uno.App(), args);
            host.Run();
        }
    }
}
