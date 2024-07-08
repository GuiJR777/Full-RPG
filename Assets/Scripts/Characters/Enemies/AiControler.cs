using RPG.Combat;
using UnityEngine;

namespace RPG.AI
{
    public class AiControler : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        GameObject playerReference;
        Fighter fighter;
        Health health;

        void Start()
        {
            playerReference = GameObject.FindGameObjectWithTag("Player");
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
        }

        void Update()
        {
            if (health.IsDead()) return;

            if (CanAttack())
            {
                fighter.Attack(playerReference);
            }
            else
            {
                fighter.Cancel();
            }
        }

        private bool CanAttack()
        {
            if (playerReference == null) return false;

            float distanceToPlayer = Vector3.Distance(playerReference.transform.position, transform.position);

            return distanceToPlayer <= chaseDistance && fighter.CanAttack(playerReference);
        }
    }
}
