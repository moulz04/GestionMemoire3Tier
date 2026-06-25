using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppClientPhp
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(path: Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "app-.log"), rollingInterval: RollingInterval.Day, retainedFileCountLimit: 14, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            Log.Information("=== Demarrage de l application ===");




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Capture des exceptions non gerees
            Application.ThreadException += (s, e) =>         
            {  Log.Fatal(e.Exception, "Exception non geree sur le thread UI");         };

            try 
            { Application.Run(new Form1()); }
            finally { Log.Information("=== Fermeture de l application ==="); Log.CloseAndFlush(); }
        }
    }
}
