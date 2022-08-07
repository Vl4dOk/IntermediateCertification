using UnityEngine;
using UnityEngine.UI;

public class Menu_Main : MonoBehaviour
{
    [SerializeField] private GameObject _menu_Main, _mainCamera;
    [SerializeField] private Button Button_Start, Button_Levels, Button_Exit;


    private void Awake()
    {
        if (_menu_Main == null) { _menu_Main = gameObject; _mainCamera = FindObjectOfType<Camera>().gameObject; }
    }

    public void Activate_Menu_Main(){ _menu_Main.SetActive(true); _mainCamera.SetActive(true); }
    public void Deactivate_Menu_Main(){ _menu_Main.SetActive(false); _mainCamera.SetActive(false); }



    public void ExitGame() 
    {
        Application.Quit();
    }
}
