using System.Windows;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using TNHTweaker_UI.BusinessLogic;
using TNHTweaker_UI.BusinessLogic.Interfaces;
using TNHTweaker_UI.CustomCharacterConverter.Views;

namespace TNHTweaker_UI.CustomCharacterConverter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        ///<inheritdoc cref="PrismApplicationBase.RegisterTypes"/>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICharacterConverter, CharacterConverter>();
            containerRegistry.RegisterSingleton<ICharacterSerializerOld, CharacterSerializerOld>();
            containerRegistry.RegisterSingleton<ICharacterSerializer, CharacterSerializer>();
        }

        ///<inheritdoc cref="PrismApplicationBase.CreateShell"/>
        protected override Window CreateShell() => Container.Resolve<MainWindow>();
    }
}