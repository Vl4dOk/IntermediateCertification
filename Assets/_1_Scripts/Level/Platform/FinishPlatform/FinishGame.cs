using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Character.Snake;

namespace Event
{

    public class FinishGame : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out SnakeHealth snake))
            {
                GlobalEventManager.Event_PlayerOnFinish?.Invoke();
            }
        }
    }
}