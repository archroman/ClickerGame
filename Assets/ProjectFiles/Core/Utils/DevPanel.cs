using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace ProjectFiles.Core.Utils
{
    public class DevPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        [Inject] private Services.SaveService _saveService;

        private void Start()
        {
            _panel.SetActive(false);
        }

        public void ResetProgress()
        {
            _saveService.ClearSave();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void TogglePanel()
        {
            _panel.SetActive(!_panel.activeSelf);
        }
    }
}