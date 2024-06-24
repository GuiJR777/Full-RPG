using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Inputs
{
    public class PlayerInputReader : MonoBehaviour, PlayerControls.IPlayerActions
    {
        public event Action LeftClick;
        public event Action CancelLeftClick;

        private PlayerControls _inputAction;

        private void Start()
        {
            _inputAction = new PlayerControls();
            _inputAction.Player.SetCallbacks(this);

            _inputAction.Player.Enable();
        }

        private void OnDestroy()
        {
            _inputAction.Player.Disable();
        }

        public void OnLeftClick(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                LeftClick?.Invoke();
            }

            if (context.canceled)
            {
                CancelLeftClick?.Invoke();
            }
        }
    }
}
