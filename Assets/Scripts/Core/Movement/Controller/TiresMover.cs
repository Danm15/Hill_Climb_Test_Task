using Core.Movement.Data;
using StatsSystem;
using StatSystem.Enum;
using UnityEngine;

namespace Core.Movement.Controller
{
    public class TiresMover
    {
        private readonly TiresData _tiresMoverData;
        private readonly IStatValueGiver _statValueGiver;
        
        public TiresMover(TiresData tiresMoverData,IStatValueGiver statValueGiver)
        {
            _tiresMoverData = tiresMoverData;
            _statValueGiver = statValueGiver;
        }
        
        public void Move(float direction)
        {
            foreach (var tire in _tiresMoverData.TiresRbs)
            {
                tire.AddTorque(_statValueGiver.GetStatValue(StatType.TierAcceleration) * -direction  *  Time.fixedDeltaTime);  
            }
        }
    }
}