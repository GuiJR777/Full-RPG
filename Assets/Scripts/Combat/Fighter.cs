using System;
using RPG.Characters.Commons;
using RPG.Core;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float attackRange = 2f;
        Mover mover;
        Transform target;

        void Start()
        {
            mover = GetComponent<Mover>();
        }

        void Update()
        {
            if (target == null) return;

            if (!IsInAttackRange())
            {
                mover.MoveTo(target.position);
            }

            if (IsInAttackRange())
            {
                GetComponent<ActionScheduler>().StartAction(this);
                Hit();
                Cancel();
            }
        }


        private bool IsInAttackRange()
        {
            return Vector3.Distance(transform.position, target.position) <= attackRange;
        }

        private void Hit()
        {
            print("Toma esse seu bobão! " + target.name + " foi atacado!");
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}
