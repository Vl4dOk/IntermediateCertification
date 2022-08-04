using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager MainMenuManager; private void Awake()
    {
        if (MainMenuManager == null) { MainMenuManager = this; }
        else if (MainMenuManager != this) { Destroy(gameObject); }
    }



    [SerializeField] private GameObject _menu_MainMenu;
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private GameObject _menu_Levels;
    [SerializeField] private GameObject _interface_Payer;
    [SerializeField] private GameObject _menu_Pause;
    [SerializeField] private GameObject _menu_VictoryScreen;
    [SerializeField] private GameObject _menu_DefeatScreen;
    [SerializeField] private GameObject _menu_Shop;
    [SerializeField] private GameObject _menu_Settings;

    private void Update()
    {
        MenuPause();
    }


    ///////////////////////////////////////////////// Main menu ////////////////////////////////////////
    public void CallingMainMenu() { _menu_MainMenu.SetActive(true); _mainCamera.SetActive(true); }
    public void CloseMainMenu() { _menu_MainMenu.SetActive(false); _mainCamera.SetActive(false); }

    public void CallingMenu_Levels() { _menu_Levels.SetActive(true); }
    public void CloseMenu_Levels() { _menu_Levels.SetActive(false); }

    public void CallingInterface_Payer() { _interface_Payer.SetActive(true); }
    public void CloseInterface_Payer() { _interface_Payer.SetActive(false); }

    public void CallingMenu_VictoryScreen() { _menu_VictoryScreen.SetActive(true); }
    public void CloseMenu_VictoryScreen() { _menu_VictoryScreen.SetActive(false); }

    public void CallingMenu_DefeatScreen() { _menu_DefeatScreen.SetActive(true); }
    public void CloseMenu_DefeatScreen() { _menu_DefeatScreen.SetActive(false); }

    public void CallingMenu_Shop() { _menu_Shop.SetActive(true); }
    public void CloseMenu_Shop() { _menu_Shop.SetActive(false); }

    public void CallingMenu_Settings() { _menu_Settings.SetActive(true); }
    public void CloseMenu_Settings() { _menu_Settings.SetActive(false); }




    /////////////////////////////////////////////////// Pause menu ////////////////////////////////////////

    [HideInInspector] public bool _isMenu_PauseIncluded = false;

    public void CallingMenu_Pause()
    {
        _isMenu_PauseIncluded = true;
        _menu_Pause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CloseMenu_Pause()
    {
        _isMenu_PauseIncluded = false;
        _menu_Pause.SetActive(false);
        Time.timeScale = 1f;
    }
    
    private void MenuPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isMenu_PauseIncluded)
            { CloseMenu_Pause(); }
            else
            { CallingMenu_Pause(); }
        }
    }




    //////////////////////////////////////////////////// Shop menu ////////////////////////////////////////



















}
