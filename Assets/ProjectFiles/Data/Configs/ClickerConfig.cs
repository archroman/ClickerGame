using UnityEngine;

namespace ProjectFiles.Data.Configs
{
    [CreateAssetMenu(fileName = "NewConfig", menuName = "Configs/ClickerConfig")]
    internal sealed class ClickerConfig : ScriptableObject
    {
        public float GoldPerClick;
    }
}