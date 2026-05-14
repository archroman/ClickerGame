using System;
using ProjectFiles.Data;

namespace ProjectFiles.Core.Services
{
    internal sealed class EconomyService
    {
        private float _currentGold;
        public float CurrentGold => _currentGold;
        
        public event Action<float> OnGoldChanged;

        public Upgrade ClickUpgrade { get; } = new Upgrade { BasePrice = 10 };
        public Upgrade AutoClickUpgrade { get; } = new Upgrade { BasePrice = 50 };

        public void AddGold(float amount)
        {
            _currentGold += amount;
            OnGoldChanged?.Invoke(_currentGold);
        }

        public void TryBuyUpgrade(Upgrade upgrade)
        {
            float currentPrice = upgrade.GetPrice();

            if (_currentGold >= currentPrice)
            {
                _currentGold -= currentPrice;
                upgrade.LevelUp();
                OnGoldChanged?.Invoke(_currentGold); 
            }
        }
        
        public Upgrade GetUpgrade(UpgradeType type)
        {
            return type switch
            {
                UpgradeType.ClickPower => ClickUpgrade,
                UpgradeType.AutoClick => AutoClickUpgrade,
                _ => null
            };
        }
        
        public void LoadData(SaveData data)
        {
            if (data == null) return;
    
            _currentGold = data.Gold;
            ClickUpgrade.Level = data.ClickLevel;
            AutoClickUpgrade.Level = data.AutoClickLevel;
    
            OnGoldChanged?.Invoke(_currentGold);
        }

        public SaveData GetSaveData()
        {
            return new SaveData
            {
                Gold = _currentGold,
                ClickLevel = ClickUpgrade.Level,
                AutoClickLevel = AutoClickUpgrade.Level
            };
        }
    }
}