using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sidewaysSpeed;
    [SerializeField] private sbyte _lateralLimit;


    private Vector3 _forwardMovement;
    private Vector3 _sidewaysMovement;

    private void Start()
    {
        _forwardMovement = new Vector3 (0,0,_forwardSpeed);
       // _sidewaysMovement = new Vector3
    }

    private void FixedUpdate()
    {
        Vector3 Movement = new Vector3();

        Movement.z += _forwardSpeed;
        if (Input.GetKey (KeyCode.D) && transform.position.x < _lateralLimit){   Movement.x += _sidewaysSpeed; }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -_lateralLimit){   Movement.x -= _sidewaysSpeed; }
        _rigidbody.transform.Translate(Movement);





    }
}
