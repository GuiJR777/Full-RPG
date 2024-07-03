using UnityEngine;

namespace RPG.AI
{
    public class AiControler : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        GameObject playerReference;

        void Start()
        {
            playerReference = GameObject.FindGameObjectWithTag("Player");
        }

        void Update()
        {
            if (Vector3.Distance(playerReference.transform.position, transform.position) <= chaseDistance)
            {
                Debug.Log(name + " can pursuit " + playerReference.name);
            }
        }
    }
}
