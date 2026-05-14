using ProjectFiles.Core.Services;
using ProjectFiles.Core.Utils;
using ProjectFiles.Data.Configs;
using ProjectFiles.Visual.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using UnityEngine.UI;

namespace ProjectFiles.DI.Scopes
{
    public class GameSceneLifetimeScope : LifetimeScope
    {
        [SerializeField] private ClickerConfig _clickerConfig;
        [SerializeField] private UpgradeDisplay[] _upgradeButtons;
        [SerializeField] private Button _devPanelButton;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<EconomyService>(Lifetime.Singleton);
            builder.Register<SaveService>(Lifetime.Singleton); 
            builder.RegisterInstance(_clickerConfig);

            builder.RegisterEntryPoint<AutoClickService>();
            builder.RegisterEntryPoint<SaveManager>(); 

            builder.RegisterComponentInHierarchy<ClickReceiver>();
            builder.RegisterComponentInHierarchy<GoldDisplay>();
            builder.RegisterComponentInHierarchy<DevPanel>();

            foreach (var button in _upgradeButtons)
            {
                autoInjectGameObjects.Add(button.gameObject);
            }
        }
    }
}