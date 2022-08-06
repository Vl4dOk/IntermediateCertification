using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Character.Snake
{
    public class SnakeHealth : MonoBehaviour
    {
        [SerializeField] private Transform _parentSnake;
        [SerializeField] private byte _startHealth;
        [HideInInspector] public int Health;

        [HideInInspector] public List<Vector3> _listPositions = new();
        [HideInInspector] public List<GameObject> _listTail = new ();
        private ShowInfoForHealth _showInfoForHealth;

        private void Awake()
        {
            _parentSnake = gameObject.GetComponentInParent<PlayerBuilder>()._player.transform;
            _showInfoForHealth = GetComponent<ShowInfoForHealth>();
            _listPositions.Add(transform.position);
             AddHealth(_startHealth);
        }


        public void AddHealth(byte numberOfHealth = 1)
        {
            Health += numberOfHealth;
            for (int i = 0; i < numberOfHealth; i++)
            {
                GameObject tail = Instantiate(Resources.Load<GameObject>("Prefabs/Player/Character/Snake/Snake(Tail)/SphereTail"),
                    new Vector3(_listPositions[_listTail.Count].x,
                                _listPositions[_listTail.Count].y,
                                _listPositions[_listTail.Count].z), Quaternion.Euler(0, 0, 0), _parentSnake);
                _listTail.Add(tail);
                _listPositions.Add(tail.transform.position);
            }
            ShowHealth();
        }

        public void RemoveHealth(byte damage = 1)
        {
            Health -= damage;
            for (int i = 0; i < damage; i++)
            {
                Destroy(_listTail[_listTail.Count - 1]);
                _listTail.RemoveAt(_listTail.Count - 1);
                if (_listTail.Count > 0)
                { _listPositions.RemoveAt(_listTail.Count - 1); }

                if (_listTail.Count <= 0)
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
