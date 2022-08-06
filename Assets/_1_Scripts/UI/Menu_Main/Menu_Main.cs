using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Main : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private Button Button_Start, Button_Levels, Button_Exit;


    



    public void Activate_Menu_Main(){ gameObject.SetActive(true); _mainCamera.SetActive(true); }
    public void Deactivate_Menu_Main(){ gameObject.SetActive(false); _mainCamera.SetActive(false); }
}
