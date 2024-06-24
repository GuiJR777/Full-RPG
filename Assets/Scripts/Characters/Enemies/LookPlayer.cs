using UnityEngine;

namespace RPG.Characters.Enemy
{
    public class LookPlayer : MonoBehaviour
    {
        GameObject player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("PlayerCharacter");
        }

        void Update()
        {
            transform.LookAt(player.transform.position);
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
        }
    }
}
