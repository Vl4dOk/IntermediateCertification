using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class FinishGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MyCameraController camera))
        {
            camera._movementSpeed = 0;

        }
    }
}
