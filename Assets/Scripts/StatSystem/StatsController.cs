using System.Collections.Generic;
using StatSystem;
using StatSystem.Enum;

namespace StatsSystem
{
    public class StatsController : IStatValueGiver
    {
        private readonly List<Stat> _currentStats;
      
        public StatsController(List<Stat> currentStats)
        {
            _currentStats = currentStats;
        }
        public float GetStatValue(StatType statType) => _currentStats.Find(stat => stat.Type == statType);
    }
}