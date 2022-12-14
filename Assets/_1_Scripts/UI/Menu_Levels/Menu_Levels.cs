using UnityEngine;
using UnityEngine.UI;
using Event;

public class Menu_Levels : MonoBehaviour
{
    [SerializeField] private GameObject _menu_Levels;
    [SerializeField] private Button[] _buttons_Levels;

    [HideInInspector] public int CurrentLevel;
    private int _maxOpenLevel;
    [HideInInspector] public bool IsEndlessLevel = false;


    private void Awake()
    {
        if (_menu_Levels == null) { _menu_Levels = gameObject; }

        LoadingSave();
        GlobalEventManager.Event_PlayerOnFinish += SaveLevel;
        Deactivate_Menu_Levels();
    }


    public void Activate_Menu_Levels() { _menu_Levels.SetActive(true); }
    public void Deactivate_Menu_Levels() { _menu_Levels.SetActive(false); }



    public void ChooseLevel(int numberLevel)
    { CurrentLevel = numberLevel;}

    public void ChooseMode()
    { IsEndlessLevel = !IsEndlessLevel;}

    private void LoadingSave()
    {
        _maxOpenLevel = PlayerPrefs.GetInt("Levels", 1);
        CurrentLevel = _maxOpenLevel;
        for (int i = 0; i < _buttons_Levels.Length; i++)
        { _buttons_Levels[i].interactable = false;}

        for (int i = 0; i < _maxOpenLevel; i++)
        { _buttons_Levels[i].interactable = true;}
    }

    private void SaveLevel()
    {
        if (CurrentLevel == _maxOpenLevel && _maxOpenLevel < _buttons_Levels.Length)
        {
            _maxOpenLevel = CurrentLevel + 1;
            PlayerPrefs.SetInt("Levels", _maxOpenLevel);

            for (int i = 0; i < _buttons_Levels.Length; i++)
            { _buttons_Levels[i].interactable = false;}
            for (int i = 0; i < _maxOpenLevel; i++)
            { _buttons_Levels[i].interactable = true;}
        }
        if (CurrentLevel == _buttons_Levels.Length)
        { CurrentLevel = 0; }
    }
}
