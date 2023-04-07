using Core.Movement.Data;
using StatsSystem;
using StatSystem.Enum;
using UnityEngine;

namespace Core.Movement.Controller
{
    public class CarMover
    {
        private readonly CarData _carMoverData;
        private readonly IStatValueGiver _statValueGiver;
        public CarMover(CarData carMoverData,IStatValueGiver statValueGiver)
        {
            _carMoverData = carMoverData;
            _statValueGiver = statValueGiver;
        }
        
        public void Move(float direction)
        {
            _carMoverData.CarRB.AddTorque(_statValueGiver.GetStatValue(StatType.CarAcceleration) * -direction  *  Time.fixedDeltaTime);
        }
    }
}