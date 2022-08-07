using System.Collections.Generic;
using UnityEngine;

namespace Player.Character.Snake
{
    public class SnakeMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
                         private Camera _cameraCharacter;
                         public float ForwardSpeed;
                         public float SidewaysSpeed;
                         private float _smoothnessMovementHorisontal;
                         private float _smoothnessMovementVertical;
        [SerializeField] private sbyte _lateralLimit;

        private List<Vector3> _listPositions;
        private List<GameObject> _listTail;

        private void Start()
        {
            _cameraCharacter = FindObjectOfType<Camera>();
            _listPositions = GetComponent<SnakeHealth>().ListPositions;
            _listTail = GetComponent<SnakeHealth>().ListTail;
        }
        

        private void FixedUpdate()
        {
            MovementHead();
            MovementTail();
        }


        private Vector3 _previousMousePosition;





        private void MovementHead()
        {   //Head save in position
            _listPositions[0] = transform.position;
            //Head moves
            Vector3 Movement = new Vector3(); Movement.z += ForwardSpeed;


            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - _previousMousePosition;
               
                if (delta.x > 0 && transform.position.x <= _lateralLimit)
                { Movement.x += 20f; }
                else if (delta.x < 0 && transform.position.x >= -_lateralLimit)
                { Movement.x -= 20f; }              
            }
            _previousMousePosition = Input.mousePosition;


            //New System Movement for smoothness
            //Horizontal
            if (transform.position.x <= -_lateralLimit || transform.position.x >= _lateralLimit)
            { _smoothnessMovementHorisontal = 0; }

            if (Input.GetKey(KeyCode.D) && transform.position.x <= _lateralLimit)
            {
                if (_smoothnessMovementHorisontal < 0)
                { _smoothnessMovementHorisontal += SidewaysSpeed; }
                _smoothnessMovementHorisontal += SidewaysSpeed;
            }
            if (Input.GetKey(KeyCode.A) && transform.position.x >= -_lateralLimit)
            {
                if (_smoothnessMovementHorisontal > 0)
                { _smoothnessMovementHorisontal -= SidewaysSpeed; }
                _smoothnessMovementHorisontal -= SidewaysSpeed;
            }
            if (_smoothnessMovementHorisontal != 0 && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                if (_smoothnessMovementHorisontal > 0)
                {
                    _smoothnessMovementHorisontal -= SidewaysSpeed;
                    if (_smoothnessMovementHorisontal < 0) { _smoothnessMovementHorisontal = 0; }
                }
                else if (_smoothnessMovementHorisontal < 0)
                {
                    _smoothnessMovementHorisontal += SidewaysSpeed;
                    if (_smoothnessMovementHorisontal > 0) { _smoothnessMovementHorisontal = 0; }
                }
            }

            Movement.x += _smoothnessMovementHorisontal;

            {

                //Vertical
                /*
                if (transform.position.y <= -_lateralLimit || transform.position.y >= _lateralLimit)           
                { _smoothnessMovementVertical = 0; }  

                if (Input.GetKey(KeyCode.S) && transform.position.y <= _lateralLimit)
                {
                    if (_smoothnessMovementVertical < 0)
                    { _smoothnessMovementVertical += SidewaysSpeed; }
                    _smoothnessMovementVertical += SidewaysSpeed;
                }
                if (Input.GetKey(KeyCode.W) && transform.position.y >= -_lateralLimit)
                {
                    if (_smoothnessMovementVertical > 0)
                    { _smoothnessMovementVertical -= SidewaysSpeed; }
                    _smoothnessMovementVertical -= SidewaysSpeed;
                }
                if (_smoothnessMovementVertical != 0 && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                {
                    if (_smoothnessMovementVertical > 0)
                    {
                        _smoothnessMovementVertical -= SidewaysSpeed;
                        if (_smoothnessMovementVertical < 0) { _smoothnessMovementVertical = 0; }
                    }
                    else if (_smoothnessMovementVertical < 0)
                    {
                        _smoothnessMovementVertical += SidewaysSpeed;
                        if (_smoothnessMovementVertical > 0) { _smoothnessMovementVertical = 0; }
                    }
                }
                Movement.y += _smoothnessMovementVertical;
                */





                //Old system Movement
                /* if (Input.GetKey(KeyCode.D) && transform.position.x < _lateralLimit) { Movement.x += SidewaysSpeed; }
                   if (Input.GetKey(KeyCode.A) && transform.position.x > -_lateralLimit) { Movement.x -= SidewaysSpeed; }
                   if (Input.GetKey(KeyCode.S) && transform.position.y < _lateralLimit) { Movement.y += SidewaysSpeed; }
                   if (Input.GetKey(KeyCode.W) && transform.position.y > -_lateralLimit) { Movement.y -= SidewaysSpeed; }*/
            }
            
            _rigidbody.velocity = Movement;
        }

        private void MovementTail()
        {
            if (_listPositions.Count == 1 || _listPositions[0] == _listPositions[1])
            { return; }

            for (int i = 0; i < _listTail.Count; i++)
            {
                _listPositions[i + 1] = _listTail[i].transform.position;
                _listTail[i].transform.position = _listPositions[i];
            }
        }
    }
}