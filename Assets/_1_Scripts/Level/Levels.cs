using UnityEngine;

namespace Level
{
    public class Levels : MonoBehaviour
    {

        private GameObject _level;
        private GameObject[] _levelPrefabs;
        private LevelBuilder _levelBuilder;

        [HideInInspector] public int NumberLevel;
        [HideInInspector] public int NumberOfPlatforms = 5;
        [HideInInspector] public bool IsEndlessLevel = false;


        public void Construct(GameObject level, int numberLevel, bool isEndlessLevel)
        {
            _level = level;
            NumberLevel = numberLevel;
            IsEndlessLevel = isEndlessLevel;
            LevelSearch();


            _level.AddComponent<LevelBuilder>();
            _levelBuilder = level.GetComponent<LevelBuilder>();
            _levelBuilder.Construct(_levelPrefabs, NumberOfPlatforms + NumberLevel, IsEndlessLevel);
        }

        private void LevelSearch()
        {
            _levelPrefabs = Resources.LoadAll<GameObject>("Prefabs/Level/_BilletLevels/Level" + NumberLevel);
        }
    }
}