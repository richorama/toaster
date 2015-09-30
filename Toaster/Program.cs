using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Toaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var title = "please supply a title and message";
            var message = "these should be the first two arguments on the command line";
            if (args.Length > 0) title = message = args[0];
            if (args.Length > 1) message = args[1];

            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(assembly.GetManifestResourceNames().First()))
            using (var notifyIcon = new NotifyIcon())
            {
                notifyIcon.Icon = new System.Drawing.Icon(stream);
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(5000, title, message, ToolTipIcon.Info);
            }
            
        }
    }
}
