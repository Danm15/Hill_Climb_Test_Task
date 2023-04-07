using System.Collections.Generic;
using StatSystem;
using UnityEngine;

namespace StatsData
{
    [CreateAssetMenu(fileName = "CarStatsStorage" , menuName = "Storage/CarStatsStorage")]
    public class CarStatsStorage : ScriptableObject
    {
        [field: SerializeField] public List<Stat> Stats { get; private set; }
    }
}