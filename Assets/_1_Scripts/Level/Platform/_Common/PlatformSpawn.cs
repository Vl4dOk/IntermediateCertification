using UnityEngine;
using Level;

public class PlatformSpawn : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<LevelBuilder>().AddPlatform();
    }

}
