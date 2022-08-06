using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Level;
using Player.Character.Snake;

public class ProgressSlider : MonoBehaviour
{
    private Slider _progressSlider;
    private LevelBuilder _levelBuilder;
    private SnakeMovement _snakeMovement;

    private void OnEnable()
    {
        _progressSlider = GetComponent<Slider>();
        _levelBuilder = FindObjectOfType<LevelBuilder>();
        _snakeMovement = FindObjectOfType<SnakeMovement>();
       
        if (_levelBuilder._isEndlessLevel)
        {
            Destroy(_progressSlider.gameObject);
            return;
        }

        _progressSlider.maxValue = (_levelBuilder._numberOfPlatforms + 1) * 100;
        _progressSlider.minValue = 0;
    }


    private void Update()
    {
        _progressSlider.value = _snakeMovement.transform.position.z;
    }


}
