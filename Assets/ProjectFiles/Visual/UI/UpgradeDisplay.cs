using ProjectFiles.Core.Services;
using ProjectFiles.Data;
using TMPro;
using UnityEngine;
using VContainer;
using ProjectFiles.Core.Utils;
using ProjectFiles.Data.Configs;

namespace ProjectFiles.Visual.UI
{
    internal sealed class UpgradeDisplay : MonoBehaviour
    {
        [Header("Settings")] [SerializeField] private UpgradeType _upgradeType;

        [Header("UI References")] [SerializeField]
        private TMP_Text _priceText;

        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _statsText;

        private EconomyService _economyService;
        private Upgrade _targetUpgrade;
        private ClickerConfig _clickerConfig;

        [Inject]
        private void Construct(EconomyService economyService, ClickerConfig clickerConfig)
        {
            _economyService = economyService;
            _clickerConfig = clickerConfig;

            _targetUpgrade = _economyService.GetUpgrade(_upgradeType);
            _economyService.OnGoldChanged += RefreshUI;
            RefreshUI(_economyService.CurrentGold);
        }

        public void OnBuyClick()
        {
            _economyService.TryBuyUpgrade(_targetUpgrade);
            RefreshUI(_economyService.CurrentGold);
        }

        private void RefreshUI(float currentGold)
        {
            if (_targetUpgrade == null) return;

            float price = _targetUpgrade.GetPrice();

            _priceText.color = currentGold >= price ? Color.green : Color.red;
            _priceText.text = $"Price: {price.ToFormattedString()}";
            _levelText.text = $"Lvl: {_targetUpgrade.Level}";

            UpdateStatsText();
        }

        private void OnDestroy()
        {
            if (_economyService != null)
                _economyService.OnGoldChanged -= RefreshUI;
        }

        private void UpdateStatsText()
        {
            if (_statsText == null) return;

            if (_upgradeType == UpgradeType.ClickPower)
            {
                float currentPower = _clickerConfig.GoldPerClick + _targetUpgrade.Level;
                _statsText.text = $"+{currentPower.ToFormattedString()} per click";
            }
            else if (_upgradeType == UpgradeType.AutoClick)
            {
                float currentAutoPower = _clickerConfig.AutoClickPower * _targetUpgrade.Level;
                _statsText.text = $"+{currentAutoPower.ToFormattedString()} per sec";
            }
        }
    }
}