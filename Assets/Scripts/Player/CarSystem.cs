using System;
using System.Collections.Generic;
using System.Linq;
using InputReader;
using StatsData;
using StatsSystem;
using UnityEngine;

namespace Player
{
    public class CarSystem : IDisposable
    {
        private readonly CarEntity _carEntity;
        private readonly CarBrain _carBrain;
        private readonly StatsController _statsController;
        private List<IDisposable> _disposables;
        public CarSystem(CarEntity carEntity , List<IEntityInputSource> inputSources)
        {
            _disposables = new List<IDisposable>();
            var statsStorage = Resources.Load<CarStatsStorage>($"Player/{nameof(CarStatsStorage)}");
            var stats = statsStorage.Stats.Select(stat => stat.GetCopy()).ToList();
            _statsController = new StatsController(stats);
            _carEntity = carEntity;
            _carEntity.Initialize(_statsController);
            
            _carBrain = new CarBrain(_carEntity, inputSources);
            _disposables.Add(_carBrain);
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}