using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sidewaysSpeed;
    [SerializeField] private sbyte _lateralLimit;




    private List<Vector3> _listPositions = new List<Vector3>();
    private List<GameObject> _listTail = new List<GameObject>();

    private void Start()
    {
        _listPositions.Add(transform.position);
        for (int i = 0; i < 40; i++)
        {
            AddTail();
        }

    }

    private void FixedUpdate()
    {
        _listPositions[0] = transform.position;

        
        Vector3 Movement = new Vector3(); Movement.z += _forwardSpeed;
        if (Input.GetKey(KeyCode.D) && transform.position.x < _lateralLimit) { Movement.x += _sidewaysSpeed; }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -_lateralLimit) { Movement.x -= _sidewaysSpeed; }
        _rigidbody.transform.Translate(Movement);
        
        if (_listPositions[0] == transform.position)
        { return; }

        for (int i = 0; i < _listTail.Count; i++)
        {
            _listPositions[i + 1] = _listTail[i].transform.position;
            _listTail[i].transform.position = _listPositions[i];
        }    





    }

    public void AddTail()
    {
        GameObject tail = Instantiate(Resources.Load<GameObject>("Prefabs/Character/Snake/Snake(Tail)/SphereTail"),
            new Vector3(_listPositions[_listTail.Count].x, 
                        _listPositions[_listTail.Count].y, 
                        _listPositions[_listTail.Count].z - 1), Quaternion.Euler(0, 0, 0)) ;
        _listTail.Add(tail);
        _listPositions.Add(tail.transform.position);
    }
}
