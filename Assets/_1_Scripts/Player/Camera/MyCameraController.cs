using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MyCameraController : MonoBehaviour
    {
        public Transform Target;

        [SerializeField] private float _movementSpeed = 1;



        private void Start()
        {
            transform.position = new Vector3(Target.position.x, Target.position.y + 30, Target.position.z + 10);
            transform.rotation = Quaternion.Euler(90,0,0);
        }

        private void FixedUpdate()
        {
            if (Target)
            {
                Vector3 target = new Vector3()
                {
                    //x = _target.position.x,
                    y = Target.position.y + 30,
                    z = Target.position.z + 10,
                };

                Vector3 pos = Vector3.Lerp(transform.position, target, _movementSpeed * Time.deltaTime);

                transform.position = pos;
            }
        }
    }
}