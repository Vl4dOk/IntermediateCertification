using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Levels : MonoBehaviour
{

    [HideInInspector] public int CurrentLevel;
    [HideInInspector] public bool IsEndlessLevel = false;
    private int _levelUnLock;
    [SerializeField] private GameObject _menu_Levels;
    [SerializeField] private Button[] _buttons_Levels;

    private void Awake()
    {
        _levelUnLock = PlayerPrefs.GetInt("Levels", 1);
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


    public void ChooseLevel(int numberLevel)
    {
        CurrentLevel = numberLevel;
    }

    public void ChooseMode()
    {
        IsEndlessLevel = !IsEndlessLevel;
    }
}
