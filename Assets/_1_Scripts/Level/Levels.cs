using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class Levels : MonoBehaviour
    {

        private GameObject _level;
        [HideInInspector] public GameObject[] _levelPrefabs;
        private LevelBuilder _levelBuilder;
       
        private byte _numberLevel;
        private bool _isEndlessLevel = false;


        public void Construct(GameObject level, byte numberLevel, bool isEndlessLevel)
        {
            _level = level;
            _numberLevel = numberLevel;
            _isEndlessLevel = isEndlessLevel;
            LevelSearch();



            _level.AddComponent<LevelBuilder>();
            _levelBuilder = level.GetComponent<LevelBuilder>();
            _levelBuilder.Construct(_levelPrefabs,(byte)(7 + _numberLevel), _isEndlessLevel);
        }

        private void LevelSearch()
        {
            _levelPrefabs = Resources.LoadAll<GameObject>("Prefabs/Level/_BilletLevels/Level" + _numberLevel);
        }




    }
}