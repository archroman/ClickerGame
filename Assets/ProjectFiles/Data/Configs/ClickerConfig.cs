using ProjectFiles.Core.Services;
using UnityEngine;

namespace ProjectFiles.Data.Configs
{
    [CreateAssetMenu(fileName = "NewConfig", menuName = "Configs/ClickerConfig")]
    internal sealed class ClickerConfig : ScriptableObject
    {
        [SerializeField] private float _goldPerClick = 1;
        [SerializeField] private float _autoClickPower = 0;
        
        public float GoldPerClick => _goldPerClick;
        public float AutoClickPower => _autoClickPower;
    }
}