using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio_2_4_Movil2_2doP
{
    public partial class App : Application
    {
        static Controllers.DBProcess dBProc;

        public static Controllers.DBProcess Instancia
        {
            get
            {
                if (dBProc == null)
                {
                    String dbname = "firmaDig.db3";
                    String dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    String dbfulp = Path.Combine(dbpath, dbname);
                    dBProc = new Controllers.DBProcess(dbfulp);
                }
                return dBProc;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
