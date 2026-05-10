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

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<EconomyService>(Lifetime.Singleton);
            builder.RegisterInstance(_clickerConfig);
            
            builder.RegisterComponentInHierarchy<GoldDisplay>();
            builder.RegisterComponentInHierarchy<ClickReceiver>();
        }
    }
}