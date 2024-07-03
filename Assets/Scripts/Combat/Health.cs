using RPG.Characters.Commons;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;


        public float GetHealth()
        {
            return health;
        }

        public void TakeDamage(float amountDamage)
        {
            health -= amountDamage;

            if (health < 0)
            {
                health = 0;
            }

            if (health == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            GetComponent<AnimationsController>().DeathAnimation();
            Destroy(gameObject, 5f);
        }

        public bool IsDead()
        {
            return health <= 0;
        }
    }
}