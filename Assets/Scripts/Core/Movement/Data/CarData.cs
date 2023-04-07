using System;
using UnityEngine;

namespace Core.Movement.Data
{
    [Serializable]
    public class CarData
    {
        [field: SerializeField] public Rigidbody2D CarRB { get; private set; }
    }
}