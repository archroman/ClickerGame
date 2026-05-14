using VContainer.Unity;
using UnityEngine;

namespace ProjectFiles.Core.Services
{
    internal sealed class SaveManager : IStartable, ITickable
    {
        private readonly EconomyService _economy;
        private readonly SaveService _saveService;
        private float _timer;

        public SaveManager(EconomyService economy, SaveService saveService)
        {
            _economy = economy;
            _saveService = saveService;
        }

        public void Start()
        {
            var data = _saveService.Load();
            _economy.LoadData(data);
        }

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer >= 10f) 
            {
                Save();
                _timer = 0;
            }
        }

        public void Save() => _saveService.Save(_economy.GetSaveData());
    }
}