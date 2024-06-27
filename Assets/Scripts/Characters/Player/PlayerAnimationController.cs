using UnityEngine;
using UnityEngine.AI;

namespace RPG.Characters.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
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

            animator.SetFloat("MoveVector", speed);
        }

        public void AttackAnimation()
        {
            animator.SetTrigger("Attack");
        }
    }
}
