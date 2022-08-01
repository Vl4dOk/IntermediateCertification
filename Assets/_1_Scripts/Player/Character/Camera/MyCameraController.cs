using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyCameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _movementSpeed;



    private void Start() => transform.position = new Vector3(_target.position.x, _target.position.y + 30, _target.position.z + 10);           

    private void FixedUpdate()
    {
        if (_target)
        {
            Vector3 target = new Vector3()
            {
                //x = _target.position.x,
                y = _target.position.y + 30,
                z = _target.position.z + 10,
            };

            Vector3 pos = Vector3.Lerp(transform.position, target, _movementSpeed * Time.deltaTime);

            transform.position = pos;
        }                
    }
}
