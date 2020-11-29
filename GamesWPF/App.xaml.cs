using AutoMapper;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using DAL;
using DAL.Concrete;
using DAL.Interfaces;
using DALef.Concrete;
using GamesWPF.Windows;
using System.Windows;
using Unity;

namespace MoviesWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IUnityContainer Container;
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            base.OnStartup(e);
            RegisterUnity();
            RegisterAutoMapper();

            Login lf = Container.Resolve<Login>();
            bool result = lf.ShowDialog() ?? false;
            if (result)
            {
                GenresListWindow glw = Container.Resolve<GenresListWindow>();
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Current.MainWindow = glw;
                glw.Show();
            }
            else
            {
                Current.Shutdown();
            }
        }

        private void RegisterAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddMaps(typeof(GamesDal).Assembly);
                });

            Container.RegisterInstance(config.CreateMapper());
        }

        private void RegisterUnity()
        {
            Container = new UnityContainer();

            Container.RegisterType<ICustomerDal, CustomerDalEf>()
                     .RegisterType<IGamesDal, GamesDal>()
                     .RegisterType<IGenreDal, GenreDalEf>()
                     .RegisterType<IGamesManager, GamesManager>()
                     .RegisterType<ILoginManager, LoginManager>();
        }
    }
}
