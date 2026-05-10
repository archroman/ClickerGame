using System;
using UnityEngine;

namespace ProjectFiles.Core.Services
{
    internal sealed class EconomyService
    {
        private float _currentGold;
        public float CurrentGold => _currentGold;
        
        public event Action<float> OnGoldChanged;
        
        public void AddGold(float amount)
        {
            _currentGold += amount;
            OnGoldChanged?.Invoke(_currentGold);
        }
    }
}