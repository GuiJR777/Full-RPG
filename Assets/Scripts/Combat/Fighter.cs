using RPG.Characters.Commons;
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
        AnimationsController animationsController;
        float timeToSinceLastAttack = 0;

        void Start()
        {
            mover = GetComponent<Mover>();
            animationsController = GetComponent<AnimationsController>();
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

                if (target.GetComponent<Health>().IsDead())
                {
                    Cancel();
                    return;
                }

                GetComponent<ActionScheduler>().StartAction(this);
                transform.LookAt(target.transform.position);
                transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                animationsController.AttackAnimation();
                timeToSinceLastAttack = 0;

            }
        }


        private bool IsInAttackRange()
        {
            if (target == null) return false;

            return Vector3.Distance(transform.position, target.position) <= attackRange;
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) return false;

            Health health = combatTarget.GetComponent<Health>();
            return health != null && !health.IsDead();
        }


        public void Attack(GameObject combatTarget)
        {
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
            animationsController.StopAttack();

        }

        // Called in animation event
        void Hit()
        {
            target?.GetComponent<Health>().TakeDamage(Random.Range(8, 12));
        }
    }
}
