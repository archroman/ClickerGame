using ProjectFiles.Core.Services;
using ProjectFiles.Data.Configs;
using UnityEngine;
using VContainer;

namespace ProjectFiles.Visual.UI
{
    public sealed class ClickReceiver : MonoBehaviour
    {
        private EconomyService _economyService;
        private ClickerConfig _clickerConfig;

        [Inject]
        private void Construct(EconomyService economyService, ClickerConfig clickerConfig)
        {
            _economyService = economyService;
            _clickerConfig = clickerConfig;
        }

        public void OnButtonClick()
        {
            float totalPower = _clickerConfig.GoldPerClick + _economyService.ClickUpgrade.Level;
            _economyService.AddGold(totalPower);
        }
    }
}