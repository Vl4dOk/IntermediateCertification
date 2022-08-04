using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Levels : MonoBehaviour
{
    [SerializeField] private GameObject _menu_Levels;
    [SerializeField] private Button[] _buttons_Levels;

    [HideInInspector] public int CurrentLevel;
    [HideInInspector] public bool IsEndlessLevel = false;
    private int _levelUnLock;
   

    private void Awake()
    {
        _levelUnLock = PlayerPrefs.GetInt("Levels", 5);
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        for (int i = 0; i < _buttons_Levels.Length; i++)
        {
            _buttons_Levels[i].interactable  = false;
        }

        for (int i = 0; i < _levelUnLock; i++)
        {
            _buttons_Levels[i].interactable = true;
        }

    }
    public void Calling_Menu_Levels() { _menu_Levels.SetActive(true); }
    public void Close_Menu_Levels() { _menu_Levels.SetActive(false); }


    public void ChooseLevel(int numberLevel)
    {
        CurrentLevel = numberLevel;
    }

    public void ChooseMode()
    {
        IsEndlessLevel = !IsEndlessLevel;
    }
}
