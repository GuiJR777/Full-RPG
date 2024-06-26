using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        MonoBehaviour currentAction;

        public void StartAction(MonoBehaviour action)
        {
            if (action == currentAction) return;

            print("Cancelling " + currentAction);
            print("Starting " + action);
            currentAction = action;
        }

        public void StopAction()
        {}
    }
}