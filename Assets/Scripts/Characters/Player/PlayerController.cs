using System;
using RPG.Characters.Commons;
using RPG.Combat;
using RPG.Inputs;
using UnityEngine;

namespace RPG.Characters.Player
{
    public class PlayerController : MonoBehaviour
    {
        PlayerInputReader playerInputReader;
        Fighter fighter;
        bool left_mouse_button_hold;

        void Start()
        {
            playerInputReader = GetComponent<PlayerInputReader>();
            fighter = GetComponent<Fighter>();

            playerInputReader.LeftClick += OnLeftClick;
            playerInputReader.CancelLeftClick += OnCancelLeftClick;
        }


        void OnDestroy()
        {
            playerInputReader.LeftClick -= OnLeftClick;
            playerInputReader.CancelLeftClick -= OnCancelLeftClick;
        }

        void Update()
        {
            if (CombatHandler()) return;
            if (MovementHandler()) return;
        }


        private bool MovementHandler()
        {
            if (!left_mouse_button_hold) return false;

            GetRayCastHitPoint(out Vector3 point, out bool hasHit);

            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(point);
                fighter.Cancel();
                return true;
            }
            return false;
        }

        private static void GetRayCastHitPoint(out Vector3 point, out bool hasHit)
        {
            hasHit = Physics.Raycast(GetMouseRay(), out RaycastHit hit);
            point = hit.point;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        private bool CombatHandler()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();

                if (target == null) continue;

                if (left_mouse_button_hold)
                {
                    fighter.Attack(target);
                    left_mouse_button_hold = false;
                    return true;
                }
            }
            return false;
        }

        void OnLeftClick()
        {
            left_mouse_button_hold = true;
        }
        private void OnCancelLeftClick()
        {
            left_mouse_button_hold = false;
        }
    }
}
