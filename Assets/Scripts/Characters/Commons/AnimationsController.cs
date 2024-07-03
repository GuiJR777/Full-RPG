using UnityEngine;
using UnityEngine.AI;

namespace RPG.Characters.Commons
{
    public class AnimationsController : MonoBehaviour
    {
        const string MOVE_VECTOR = "MoveVector";
        const string ATTACK = "Attack";
        const string STOP_ATTACK = "StopAttack";
        const string DIE = "Die";

        Animator animator;

        void Start()
        {
            animator =  GetComponent<Animator>();
        }

        void Update()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;

            animator.SetFloat(MOVE_VECTOR, speed);
        }

        public void AttackAnimation()
        {
            animator.ResetTrigger(STOP_ATTACK);
            animator.SetTrigger(ATTACK);
        }

        public void StopAttack()
        {
            animator.ResetTrigger(ATTACK);
            animator.SetTrigger(STOP_ATTACK);
        }

        public void DeathAnimation()
        {
            animator.SetTrigger(DIE);
        }
    }
}
