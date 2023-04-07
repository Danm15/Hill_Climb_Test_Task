using Core.Movement.Controller;
using Core.Movement.Data;
using StatsSystem;
using UnityEngine;

namespace Player
{
    public class CarEntity : MonoBehaviour
    {
        [Header("Car")]
        [SerializeField] private CarData _carMoverData;

        [Header("Tires")] 
        [SerializeField] private TiresData _tiresMoverData;

        private CarMover _carMover;
        private TiresMover _tiresMover;
        
        
        public void Initialize(IStatValueGiver statValueGiver)
        {
            _carMover = new CarMover(_carMoverData,statValueGiver);
            _tiresMover = new TiresMover(_tiresMoverData,statValueGiver);
        }

        public void Move(float direction)
        {
            _carMover.Move(direction); 
            _tiresMover.Move(direction);
        }
    }
}