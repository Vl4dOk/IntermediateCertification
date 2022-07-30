using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private byte _platformNumber;
    private byte _numberOfPlatforms = 2;

    private void Start()
    {
        for (int i = 0; i < _numberOfPlatforms; i++)
        {
            AddPlatform();
        }
    }

    public void AddPlatform()
    {
        
        GameObject newPlatform = Instantiate(Resources.Load<GameObject>("Prefabs/Level/Platform/Platform"), new Vector3(0,0, 100 * _platformNumber),Quaternion.identity,transform);
        _platformNumber++;
    }


}
