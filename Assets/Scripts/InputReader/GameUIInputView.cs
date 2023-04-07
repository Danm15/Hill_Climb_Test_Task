using System;
using Core.UIButtons;
using UnityEngine;
using UnityEngine.UI;

namespace InputReader
{
    public class GameUIInputView : MonoBehaviour,IEntityInputSource
    {
        [SerializeField] private ControlButtons _brakeButton;
        [SerializeField] private ControlButtons _accelerationButton;
        
        public float Direction => _brakeButton.Direction != 0 ? -_brakeButton.Direction : _accelerationButton.Direction;
    }
}