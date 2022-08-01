using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level 
{
    public class LevelBuilder : MonoBehaviour
    {
        private byte _platformNumber;
        private byte _maxPlatformNumber = 10;
        private byte _numberOfPlatforms = 0;

        private void Start()
        {
            for (int i = 0; i < 2; i++)
            {
                AddPlatform();
            }
        }


        public void AddPlatform()
        {
            if (_platformNumber == 0) { AddStartPlatform(); }
            else if (_platformNumber <= _maxPlatformNumber) { AddLevelPlatform(); }
            else { AddFinishPlatform(); }
        }

        private void AddStartPlatform()
        {
            GameObject newPlatform = Instantiate(Resources.Load<GameObject>("Prefabs/Level/Platform/StartPlatform"), new Vector3(0, 0, 100 * _platformNumber), Quaternion.identity, transform);
            _platformNumber++;
        }
        private void AddLevelPlatform()
        {
            GameObject newPlatform = Instantiate(Resources.Load<GameObject>("Prefabs/Level/_BilletPlatform/Billet" + Random.Range(0, 3)), new Vector3(0, 0, 100 * _platformNumber), Quaternion.identity, transform);
            _platformNumber++;
        }
        private void AddFinishPlatform()
        {

        }

    }
}
