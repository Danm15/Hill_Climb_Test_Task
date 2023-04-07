using System;
using System.Collections.Generic;
using System.Linq;
using Player;
using Core.Services.Updater;
using InputReader;

namespace Player
{
    public class CarBrain : IDisposable
    {
        private readonly CarEntity _carEntity;
        private readonly List<IEntityInputSource>  _inputSources;
        
        public CarBrain(CarEntity carEntity, List<IEntityInputSource>  inputSources)
        {
            _carEntity = carEntity;
            _inputSources = inputSources;
            ProjectUpdater.Instance.FixedUpdateCalled += OnFixedUpdate;
        }
        public void Dispose() => ProjectUpdater.Instance.FixedUpdateCalled -= OnFixedUpdate;
        
        private void OnFixedUpdate()
        {
            _carEntity.Move(GetDirection());
        }

        private float GetDirection()
        {
            foreach (var input in _inputSources)
            {
                if(input.Direction == 0)
                    continue;

                return input.Direction;
            }

            return 0;
        }
    }
}