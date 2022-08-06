using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Defeat : MonoBehaviour
{
    [SerializeField] private GameObject _menu_Defeat;

    private void Awake()
    {
        if (_menu_Defeat == null) { _menu_Defeat = gameObject; }

        GlobalEventManager.Event_PlayerDied += Activate_Menu_Defeat;

        Deactivate_Menu_Defeat();
    }


    public void Activate_Menu_Defeat(){ _menu_Defeat.SetActive(true);}
    public void Deactivate_Menu_Defeat(){ _menu_Defeat.SetActive(false);}

}
