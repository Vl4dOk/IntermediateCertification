using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class Levels : MonoBehaviour
    {
        private GameObject _level;
        private LevelBuilder _levelBuilder;
       
        private byte _numberLevel;
        private bool _isEndlessLevel = false;


        public void Construct(GameObject level, byte numberLevel, bool isEndlessLevel)
        {
            _level = level;
            _numberLevel = numberLevel;
            _isEndlessLevel = isEndlessLevel;


            _level.AddComponent<LevelBuilder>();
            _levelBuilder = level.GetComponent<LevelBuilder>();
            //_levelBuilder.Construct();
        }

    }
}