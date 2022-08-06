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

        [HideInInspector] public int _numberLevel;
        [HideInInspector] public int _numberOfPlatforms = 5;
        [HideInInspector] public bool _isEndlessLevel = false;


        public void Construct(GameObject level, int numberLevel, bool isEndlessLevel)
        {
            _level = level;
            _numberLevel = numberLevel;
            _isEndlessLevel = isEndlessLevel;
            LevelSearch();



            _level.AddComponent<LevelBuilder>();
            _levelBuilder = level.GetComponent<LevelBuilder>();
            _levelBuilder.Construct(_levelPrefabs, _numberOfPlatforms + _numberLevel, _isEndlessLevel);
        }

        private void LevelSearch()
        {
            _levelPrefabs = Resources.LoadAll<GameObject>("Prefabs/Level/_BilletLevels/Level" + _numberLevel);
        }




    }
}