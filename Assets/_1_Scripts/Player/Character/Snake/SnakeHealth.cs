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

        [HideInInspector] public List<Vector3> _listPositions = new List<Vector3>();
        [HideInInspector] public List<GameObject> _listTail = new List<GameObject>();
        private ShowInfoForHealth _showInfoForHealth;

        private void Start()
        {
            _showInfoForHealth = GetComponent<ShowInfoForHealth>();            
            _listPositions.Add(transform.position);            
             AddHealth((byte)(_startHealth));
            
        }


        public void AddHealth(byte numberOfHealth = 1)
        {
            Health += numberOfHealth;
            for (int i = 0; i < numberOfHealth; i++)
            {
                GameObject tail = Instantiate(Resources.Load<GameObject>("Prefabs/Character/Snake/Snake(Tail)/SphereTail"),
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
                { Destroy(gameObject); }
            }
            ShowHealth();
         
        }

        private void ShowHealth()
        {
            _showInfoForHealth.ShowInfo(Health);
        }

    }
}
