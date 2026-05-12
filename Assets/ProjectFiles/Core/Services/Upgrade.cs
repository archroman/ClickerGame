using UnityEngine;

namespace ProjectFiles.Core.Services
{
    internal sealed class Upgrade
    {
        public int Level;
        public float BasePrice;
        public float PriceMultiplier = 1.15f;

        public float GetPrice()
        {
            return BasePrice * Mathf.Pow(PriceMultiplier, Level);
        }

        public void LevelUp()
        {
            Level++;
        }
    }
}