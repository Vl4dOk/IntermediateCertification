using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Character.Snake
{
    public class SnakeMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
                         public float _forwardSpeed;
                         public float _sidewaysSpeed;
                         private float _smoothnessMovementHorisontal;
                         private float _smoothnessMovementVertical;
        [SerializeField] private sbyte _lateralLimit;
       // private ShowInfoForHealth _showInfoForHealth;

        private List<Vector3> _listPositions;
        private List<GameObject> _listTail;

        private void Start()
        {
            _listPositions = GetComponent<SnakeHealth>()._listPositions;
            _listTail = GetComponent<SnakeHealth>()._listTail;
        }
        

        private void FixedUpdate()
        {
            MovementHead();
            MovementTail();
        }


        private void MovementHead()
        {   //Head save in position
            _listPositions[0] = transform.position;
            //Head moves
            Vector3 Movement = new Vector3(); Movement.z += _forwardSpeed;


            //New System Movement for smoothness
            //Horizontal

            if (transform.position.x <= -_lateralLimit || transform.position.x >= _lateralLimit)          
            { _smoothnessMovementHorisontal = 0; }      

            if (Input.GetKey(KeyCode.D) && transform.position.x <= _lateralLimit)
            {
                if (_smoothnessMovementHorisontal < 0)
                { _smoothnessMovementHorisontal += _sidewaysSpeed; }
                _smoothnessMovementHorisontal += _sidewaysSpeed;
            }
            if (Input.GetKey(KeyCode.A) && transform.position.x >= -_lateralLimit)
            {
                if (_smoothnessMovementHorisontal > 0)
                { _smoothnessMovementHorisontal -= _sidewaysSpeed; }
                _smoothnessMovementHorisontal -= _sidewaysSpeed;
            }           
            if (_smoothnessMovementHorisontal != 0 && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                if (_smoothnessMovementHorisontal > 0)
                {
                    _smoothnessMovementHorisontal -= _sidewaysSpeed;
                    if(_smoothnessMovementHorisontal < 0) { _smoothnessMovementHorisontal = 0; }
                }
                else if (_smoothnessMovementHorisontal < 0)
                {
                    _smoothnessMovementHorisontal += _sidewaysSpeed;
                    if (_smoothnessMovementHorisontal > 0) { _smoothnessMovementHorisontal = 0; }
                }
            }
            
            Movement.x += _smoothnessMovementHorisontal;



            //Vertical
            /*
            if (transform.position.y <= -_lateralLimit || transform.position.y >= _lateralLimit)           
            { _smoothnessMovementVertical = 0; }  

            if (Input.GetKey(KeyCode.S) && transform.position.y <= _lateralLimit)
            {
                if (_smoothnessMovementVertical < 0)
                { _smoothnessMovementVertical += _sidewaysSpeed; }
                _smoothnessMovementVertical += _sidewaysSpeed;
            }
            if (Input.GetKey(KeyCode.W) && transform.position.y >= -_lateralLimit)
            {
                if (_smoothnessMovementVertical > 0)
                { _smoothnessMovementVertical -= _sidewaysSpeed; }
                _smoothnessMovementVertical -= _sidewaysSpeed;
            }
            if (_smoothnessMovementVertical != 0 && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                if (_smoothnessMovementVertical > 0)
                {
                    _smoothnessMovementVertical -= _sidewaysSpeed;
                    if (_smoothnessMovementVertical < 0) { _smoothnessMovementVertical = 0; }
                }
                else if (_smoothnessMovementVertical < 0)
                {
                    _smoothnessMovementVertical += _sidewaysSpeed;
                    if (_smoothnessMovementVertical > 0) { _smoothnessMovementVertical = 0; }
                }
            }
            Movement.y += _smoothnessMovementVertical;
            */




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
    

/*
        private void ShowHealth()
        {
            _showInfoForHealth.ShowInfo(_listPositions.Count);
        }
    */
    
    
    }
}