using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class Levels : MonoBehaviour
    {
        private GameObject _level;
        private LevelBuilder _levelBuilder;



        public void Construct(GameObject level)
        {
            _level = level;

            _level.AddComponent<LevelBuilder>();
            _levelBuilder = level.GetComponent<LevelBuilder>();
            //_levelBuilder.Construct();
        }

    }
}