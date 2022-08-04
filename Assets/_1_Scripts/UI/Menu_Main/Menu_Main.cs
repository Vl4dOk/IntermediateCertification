using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Main : MonoBehaviour
{
    [SerializeField] private GameObject _menu_Main, _mainCamera;
    [SerializeField] private Button Button_Start, Button_Levels, Button_Exit;


    



    public void Callding_Menu_Main(){ _menu_Main.SetActive(true); _mainCamera.SetActive(true); }
    public void Clouse_Menu_Main(){  _menu_Main.SetActive(false); _mainCamera.SetActive(false); }
}
