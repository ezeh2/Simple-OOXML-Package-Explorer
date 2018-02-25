namespace PackageExplorer
{
    using System;
    using PackageExplorer.Views;
    using WinApp = System.Windows.Forms.Application;

    static class Entry
    {
        [STAThread]
        static void Main()
        {
            WinApp.EnableVisualStyles();
            WinApp.SetCompatibleTextRenderingDefault(false);
            WinApp.Run(new Workbench());
        }
    }
}
