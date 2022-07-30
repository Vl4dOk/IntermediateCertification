using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private byte _numberPlatform;

    private void Start()
    {
        AddPlatform();
        AddPlatform(); 
    }

    public void AddPlatform()
    {
        GameObject gameObject = Instantiate(Resources.Load<GameObject>("Prefabs/Level/Platform"), new Vector3(0,0,50 * _numberPlatform),Quaternion.identity,transform);
        _numberPlatform++;
    }


}
