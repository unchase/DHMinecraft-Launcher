using System;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace DHMinecraft_Launcher
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            /* Retrieve the application Guid attribute. Alternative you can simply use the application name to initialize the Mutex 
             * but it might be risky as other programs might have similar name and make use of the Mutex class as well. */
            var appGuid = (GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0];

            // The boolean that will store the value if Mutex was successfully created which will mean that our application is not already running.

            // Initialize the Mutex object.
            using (new Mutex(true, appGuid.Value, out var createdNew))
            {
                /* If Mutex was created successfully which means our application is not running run the application as usual
                 * or else display a message and close the application.*/
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMainLauncher());
                }
                else
                {
                    MessageBox.Show("Приложение уже было запущено.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
