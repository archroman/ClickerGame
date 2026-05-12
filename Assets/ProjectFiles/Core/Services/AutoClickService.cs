using ProjectFiles.Data.Configs;
using UnityEngine;
using VContainer.Unity;

namespace ProjectFiles.Core.Services
{
    internal sealed class AutoClickService : ITickable
    {
        private float _timer;
        private ClickerConfig _clickerConfig;
        private EconomyService _economyService;

        public AutoClickService(ClickerConfig clickerConfig, EconomyService economyService)
        {
            _clickerConfig = clickerConfig;
            _economyService = economyService;
        }

        public void Tick()
        {
            _timer += Time.deltaTime;

            if (_timer >= 1f)
            {
                float totalAutoPower = _clickerConfig.AutoClickPower * _economyService.AutoClickUpgrade.Level;
                _economyService.AddGold(totalAutoPower);
                _timer = 0;
            }
        }
    }
}