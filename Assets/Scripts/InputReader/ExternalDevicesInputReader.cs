using UnityEngine;

namespace InputReader
{
    public class ExternalDevicesInputReader : IEntityInputSource
    {
        public float Direction => Input.GetAxisRaw("Horizontal");
    }
}

