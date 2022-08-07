using System.Collections.Generic;
using UnityEngine;
using Event;

namespace Player.Character.Snake
{
    public class SnakeHealth : MonoBehaviour
    {
        [SerializeField] private Transform _parentSnake;
        [SerializeField] private byte _startHealth;
        [HideInInspector] public int Health;

        [HideInInspector] public List<Vector3> ListPositions = new();
        [HideInInspector] public List<GameObject> ListTail = new ();
        private ShowInfoForHealth _showInfoForHealth;

        private void Awake()
        {
            _parentSnake = gameObject.GetComponentInParent<PlayerBuilder>().Player.transform;
            _showInfoForHealth = GetComponent<ShowInfoForHealth>();
            ListPositions.Add(transform.position);
             AddHealth(_startHealth);
        }


        public void AddHealth(byte numberOfHealth = 1)
        {
            Health += numberOfHealth;
            for (int i = 0; i < numberOfHealth; i++)
            {
                GameObject tail = Instantiate(Resources.Load<GameObject>("Prefabs/Player/Character/Snake/Snake(Tail)/SphereTail"),
                    new Vector3(ListPositions[ListTail.Count].x,
                                ListPositions[ListTail.Count].y,
                                ListPositions[ListTail.Count].z), Quaternion.Euler(0, 0, 0), _parentSnake);
                ListTail.Add(tail);
                ListPositions.Add(tail.transform.position);
            }
            ShowHealth();
        }

        public void RemoveHealth(byte damage = 1)
        {
            Health -= damage;
            for (int i = 0; i < damage; i++)
            {
                Destroy(ListTail[ListTail.Count - 1]);
                ListTail.RemoveAt(ListTail.Count - 1);
                if (ListTail.Count > 0)
                { ListPositions.RemoveAt(ListTail.Count - 1); }

                if (ListTail.Count <= 0)
                {
                    Destroy(gameObject);
                    GlobalEventManager.Event_PlayerDied.Invoke();
                    return;
                }
            }
            ShowHealth();
         
        }

        private void ShowHealth()
        {
            _showInfoForHealth.ShowInfo(Health);
        }

    }
}
