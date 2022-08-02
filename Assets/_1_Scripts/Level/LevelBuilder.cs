using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level 
{
    public class LevelBuilder : MonoBehaviour
    {
        private GameObject[] _levelPrefabs;
        private byte _numberOfPlatforms;
        private bool _isEndlessLevel;       
        private byte _platformNumber = 0;



        public void Construct(GameObject[] levelPrefabs, byte numberOfPlatforms, bool isEndlessLevel)
        {
            _levelPrefabs = levelPrefabs;
            _numberOfPlatforms = numberOfPlatforms;
            _isEndlessLevel = isEndlessLevel;
        }


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
            else if (_platformNumber <= _numberOfPlatforms || _isEndlessLevel) { AddLevelPlatform(); }
            else { AddFinishPlatform(); }
        }

        private void AddStartPlatform()
        {
            GameObject newPlatform = Instantiate(Resources.Load<GameObject>("Prefabs/Level/Platform/StartPlatform"), new Vector3(0, 0, 100 * _platformNumber), Quaternion.identity, transform);
            _platformNumber++;
        }
        private void AddLevelPlatform()
        {
            GameObject newPlatform = Instantiate(_levelPrefabs[Random.Range(0,_levelPrefabs.Length)], new Vector3(0, 0, 100 * _platformNumber), Quaternion.identity, transform);
            _platformNumber++;
        }
        private void AddFinishPlatform()
        {
            GameObject newPlatform = Instantiate(Resources.Load<GameObject>("Prefabs/Level/Platform/FinishPlatform"), new Vector3(0, 0, 100 * _platformNumber), Quaternion.identity, transform);           
        }

    }
}
