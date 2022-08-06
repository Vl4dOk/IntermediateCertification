using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface_Player : MonoBehaviour
{
    

    private void OnEnable()
    {
        GlobalEventManager.Event_StartGame += Activate_Interface_Payer;
        GlobalEventManager.Event_FinishGame -= Deactivate_Interface_Payer;
    }



    private void OnDisable()
    {
        GlobalEventManager.Event_FinishGame -= Deactivate_Interface_Payer;
        GlobalEventManager.Event_StartGame += Activate_Interface_Payer;
    }

    public void Activate_Interface_Payer() { gameObject.SetActive(true); }
    public void Deactivate_Interface_Payer() { gameObject.SetActive(false); }
}
