using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MyCameraController : MonoBehaviour
    {
        public Transform Target;

        public float _movementSpeed = 1;



        private void Start()
        {
            transform.SetPositionAndRotation(new Vector3(Target.position.x, Target.position.y + 38, Target.position.z + 10), 
                            Quaternion.Euler(new Vector3(90, 0,0)));
        }

        private void FixedUpdate()
        {
            if (Target)
            {
                Vector3 target = new()
                {
                    //x = _target.position.x,
                    y = Target.position.y + 38,
                    z = Target.position.z + 10,
                };

                Vector3 pos = Vector3.Lerp(transform.position, target, _movementSpeed * Time.deltaTime);

                transform.position = pos;
            }
        }
    }
}