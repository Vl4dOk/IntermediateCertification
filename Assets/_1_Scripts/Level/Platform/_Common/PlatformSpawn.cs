using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;

public class PlatformSpawn : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<LevelBuilder>().AddPlatform();
    }

}
