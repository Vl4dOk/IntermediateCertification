using UnityEngine;

using Player.Character.Snake;

namespace Level.Food
{
    public class Food : MonoBehaviour
    {
        public byte NumberOfLivesRestored;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out SnakeHealth snake))
            {
                snake.AddHealth(NumberOfLivesRestored);
                Destroy(gameObject);
            }
        }
    }
}
