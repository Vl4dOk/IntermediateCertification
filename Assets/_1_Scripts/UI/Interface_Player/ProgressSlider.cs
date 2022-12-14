using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Event;
using Level;
using Player.Character.Snake;

public class ProgressSlider : MonoBehaviour
{
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private TextMeshProUGUI _currentLevel;
    [SerializeField] private TextMeshProUGUI _nextLevel;

    private Levels _levels;
    private SnakeMovement _snakeMovement;


    private void Awake(){ GlobalEventManager.Event_StartGame += LoadingInfo; }  

    private void Update(){ if (_snakeMovement != null){ _progressSlider.value = _snakeMovement.transform.position.z;}}

    private void LoadingInfo()
    {    
        _progressSlider = GetComponent<Slider>();
        _levels = FindObjectOfType<Levels>();

        if (_levels.IsEndlessLevel) { _progressSlider.gameObject.SetActive(false); return; }
        else { _progressSlider.gameObject.SetActive(true); }
        
        _snakeMovement = FindObjectOfType<SnakeMovement>();

        _progressSlider.minValue = 0;
        _progressSlider.maxValue = (_levels.NumberOfPlatforms + _levels.NumberLevel) * 100;

        _currentLevel.text = _levels.NumberLevel.ToString();
        _nextLevel.text = (_levels.NumberLevel + 1).ToString();
    }
}
