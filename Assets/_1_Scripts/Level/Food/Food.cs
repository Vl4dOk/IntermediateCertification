using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Character.Snake;

namespace Level.Food
{
    public class Food : MonoBehaviour
    {
        public byte NumberOfLivesRestored;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out SnakeMovement snake))
            {
                for (int i = 0; i < NumberOfLivesRestored; i++)
                { snake.AddTail(); }
                Destroy(gameObject);
            }


        }
    }
}
