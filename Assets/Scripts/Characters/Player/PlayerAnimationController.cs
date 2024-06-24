using UnityEngine;
using UnityEngine.AI;

namespace RPG.Characters.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] GameObject body;

        void Update()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;

            body.GetComponent<Animator>().SetFloat("MoveVector", speed);
        }
    }
}
