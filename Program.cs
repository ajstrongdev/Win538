using System.Diagnostics;

namespace Win538Electors
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string aiDifficulty = "Normal";
            if (args != null && args.Length > 0)
            {
                if (args[0] == "--easy" || args[0] == "-e")
                {
                    aiDifficulty = "Easy";
                }
                else if (args[0] == "--normal" || args[0] == "-n")
                {
                    aiDifficulty = "Normal";
                }
                else if (args[0] == "--hard" || args[0] == "-h")
                {
                    aiDifficulty = "Hard";
                } 
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(aiDifficulty));
        }
    }
}