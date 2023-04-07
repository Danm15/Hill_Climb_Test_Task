using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Movement.Data
{
    [Serializable]
    public class TiresData
    {
        [field: SerializeField] public List<Rigidbody2D> TiresRbs { get; private set; }
    }
}