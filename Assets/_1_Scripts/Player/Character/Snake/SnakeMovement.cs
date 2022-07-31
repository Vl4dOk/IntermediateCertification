using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Character.Snake
{
    public class SnakeMovement : MonoBehaviour
    {
        [SerializeField] private Transform _parentSnake;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _forwardSpeed;
        [SerializeField] private float _sidewaysSpeed;
        private float _smoothnessMovement;
        [SerializeField] private sbyte _lateralLimit;
        private ShowInfoForHealth _showInfoForHealth;

        private List<Vector3> _listPositions = new List<Vector3>();
        private List<GameObject> _listTail = new List<GameObject>();

        private void Start()
        {
            
            _listPositions.Add(transform.position);
            for (int i = 0; i < 0; i++)
            {
                AddTail();
            }

            _showInfoForHealth = GetComponent<ShowInfoForHealth>();
            ShowHealth();
        }

        private void FixedUpdate()
        {
            MovementHead();
            MovementTail();
        }


        public void AddTail()
        {
            GameObject tail = Instantiate(Resources.Load<GameObject>("Prefabs/Character/Snake/Snake(Tail)/SphereTail"),
                new Vector3(_listPositions[_listTail.Count].x,
                            _listPositions[_listTail.Count].y,
                            _listPositions[_listTail.Count].z), Quaternion.Euler(0, 0, 0), _parentSnake);
            _listTail.Add(tail);
            _listPositions.Add(tail.transform.position);

            ShowHealth();
        }


        public void RemoveTail()
        {
            if (_listTail.Count > 0)
            {
                Destroy(_listTail[_listTail.Count - 1]);
                _listTail.RemoveAt(_listTail.Count - 1);
                if (_listTail.Count > 0)
                { _listPositions.RemoveAt(_listTail.Count - 1); }
                ShowHealth();
            }
            else
            { Destroy(gameObject); }
        }



        private void MovementHead()
        {   //Head save in position
            _listPositions[0] = transform.position;
            //Head moves
            Vector3 Movement = new Vector3(); Movement.z += _forwardSpeed;


            //New System Movement for smoothness
            
            if (transform.position.x <= -_lateralLimit || transform.position.x >= _lateralLimit)
            {  _smoothnessMovement = 0;}

            if (Input.GetKey(KeyCode.D) && transform.position.x <= _lateralLimit)
            {
                if (_smoothnessMovement < 0)
                { _smoothnessMovement += _sidewaysSpeed; }
                _smoothnessMovement += _sidewaysSpeed;
            }
            if (Input.GetKey(KeyCode.A) && transform.position.x >= -_lateralLimit)
            {
                if (_smoothnessMovement > 0)
                { _smoothnessMovement -= _sidewaysSpeed; }
                _smoothnessMovement -= _sidewaysSpeed;
            }
           
            if (_smoothnessMovement != 0 && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                if (_smoothnessMovement > 0)
                {
                    _smoothnessMovement -= _sidewaysSpeed;
                    if(_smoothnessMovement < 0) { _smoothnessMovement = 0; }
                }
                else if (_smoothnessMovement < 0)
                {
                    _smoothnessMovement += _sidewaysSpeed;
                    if (_smoothnessMovement > 0) { _smoothnessMovement = 0; }
                }
            }
            Movement.x += _smoothnessMovement;
           


            //Old system Movement
         /* if (Input.GetKey(KeyCode.D) && transform.position.x < _lateralLimit) { Movement.x += _sidewaysSpeed; }
            if (Input.GetKey(KeyCode.A) && transform.position.x > -_lateralLimit) { Movement.x -= _sidewaysSpeed; }
            if (Input.GetKey(KeyCode.S) && transform.position.y < _lateralLimit) { Movement.y += _sidewaysSpeed; }
            if (Input.GetKey(KeyCode.W) && transform.position.y > -_lateralLimit) { Movement.y -= _sidewaysSpeed; }*/
            _rigidbody.transform.Translate(Movement);
        }

        private void MovementTail()
        {
            if (_listPositions.Count == 1 || _listPositions[0] == _listPositions[1])
            { return; }

            for (int i = 0; i < _listTail.Count; i++)
            {
                _listPositions[i + 1] = _listTail[i].transform.position;//Tail_X save in position
                _listTail[i].transform.position = _listPositions[i];//Tail_X moves in position Tail_X-1
            }
        }
    


        private void ShowHealth()
        {
            _showInfoForHealth.ShowInfo(_listPositions.Count);
        }
    
    
    
    }
}