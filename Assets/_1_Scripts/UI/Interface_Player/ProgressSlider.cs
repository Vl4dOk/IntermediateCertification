using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Level;
using Player.Character.Snake;

public class ProgressSlider : MonoBehaviour
{
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private TextMeshProUGUI _currentLevel;
    [SerializeField] private TextMeshProUGUI _nextLevel;

    private Levels _levels;
    private SnakeMovement _snakeMovement;


    private void Awake()
    {
        GlobalEventManager.Event_StartGame += LoadingInfo;
    }

    private void Update()
    {
        if (_snakeMovement != null)
        _progressSlider.value = _snakeMovement.transform.position.z;
    }

    private void LoadingInfo()
    {
        _progressSlider = GetComponent<Slider>();
        _levels = FindObjectOfType<Levels>();
        _snakeMovement = FindObjectOfType<SnakeMovement>();

        if (_levels._isEndlessLevel)
        {
            Destroy(_progressSlider.gameObject);
            return;
        }

        _currentLevel.text = _levels._numberLevel.ToString();
        _nextLevel.text = (_levels._numberLevel+1).ToString();


        _progressSlider.minValue = 0;
        _progressSlider.maxValue = (_levels._numberOfPlatforms + _levels._numberLevel) * 100;
        

    }
}
