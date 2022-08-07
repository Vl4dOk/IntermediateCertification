using UnityEngine;
using Event;

public class Interface_Player : MonoBehaviour
{
    [SerializeField] private GameObject _interface_Player;

    private void Awake()
    {
        if (_interface_Player == null) 
        { _interface_Player = gameObject; }
        GlobalEventManager.Event_StartGame += Activate_Interface_Payer;
        GlobalEventManager.Event_FinishGame += Deactivate_Interface_Payer;

        Deactivate_Interface_Payer();
    }

    public void Activate_Interface_Payer() { _interface_Player.SetActive(true); }
    public void Deactivate_Interface_Payer() { _interface_Player.SetActive(false); }
}
