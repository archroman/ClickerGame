using System;
using ProjectFiles.Core.Services;
using TMPro;
using UnityEngine;
using VContainer;
using ProjectFiles.Core.Utils;

namespace ProjectFiles.Visual.UI
{
    internal sealed class GoldDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _goldText;

        private EconomyService _economyService;

        [Inject]
        private void Construct(EconomyService economyService)
        {
            _economyService = economyService;
            UpdateDisplay(_economyService.CurrentGold);
        }

        private void OnEnable()
        {
            _economyService.OnGoldChanged += UpdateDisplay;
        }

        private void OnDisable()
        {
            _economyService.OnGoldChanged -= UpdateDisplay;
        }

        private void UpdateDisplay(float currentGold)
        {
            _goldText.text = currentGold.ToFormattedString();
        }
    }
}