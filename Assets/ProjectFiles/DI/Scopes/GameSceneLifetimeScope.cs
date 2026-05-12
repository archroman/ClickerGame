using ProjectFiles.Core.Services;
using ProjectFiles.Data.Configs;
using ProjectFiles.Visual.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ProjectFiles.DI.Scopes
{
    public class GameSceneLifetimeScope : LifetimeScope
    {
        [SerializeField] private ClickerConfig _clickerConfig;
        [SerializeField] private UpgradeDisplay[] _upgradeButtons;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<EconomyService>(Lifetime.Singleton);
            builder.RegisterInstance(_clickerConfig);
            builder.RegisterEntryPoint<AutoClickService>();

            builder.RegisterComponentInHierarchy<ClickReceiver>();
            builder.RegisterComponentInHierarchy<GoldDisplay>();

            foreach (var button in _upgradeButtons)
            {
                autoInjectGameObjects.Add(button.gameObject);
            }
        }
    }
}