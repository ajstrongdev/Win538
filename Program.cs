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
                if (args[0] == "Easy")
                {
                    aiDifficulty = "Easy";
                }
                else if (args[0] == "Normal")
                {
                    aiDifficulty = "Normal";
                }
                else if (args[0] == "Hard")
                {
                    aiDifficulty = "Hard";
                }
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(aiDifficulty));
        }
    }
}