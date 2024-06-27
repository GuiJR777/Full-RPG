using System;
using RPG.Characters.Commons;
using RPG.Characters.Player;
using RPG.Core;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float attackRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        Mover mover;
        Transform target;
        float timeToSinceLastAttack = 0;

        void Start()
        {
            mover = GetComponent<Mover>();
        }

        void Update()
        {
            timeToSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!IsInAttackRange())
            {
                mover.MoveTo(target.position);
            }

            if (IsInAttackRange())
            {
                if (timeToSinceLastAttack < timeBetweenAttacks) return;

                GetComponent<ActionScheduler>().StartAction(this);
                transform.LookAt(target.transform.position);
                transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                GetComponent<PlayerAnimationController>().AttackAnimation();
                timeToSinceLastAttack = 0;
            }
        }


        private bool IsInAttackRange()
        {
            if (target == null) return false;

            return Vector3.Distance(transform.position, target.position) <= attackRange;
        }


        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }

        // Called in animation event
        void Hit()
        {
            print("Toma esse seu bobão! " + target?.name + " foi atacado!");
        }
    }
}
