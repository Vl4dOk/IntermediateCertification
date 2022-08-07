using UnityEngine;
using Player.Character.Snake;
using Event;

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