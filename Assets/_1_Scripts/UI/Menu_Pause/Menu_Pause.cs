using UnityEngine;
using Event;

public class Menu_Pause : MonoBehaviour
{
    [SerializeField] private GameObject _menu_Pause_Parrent;
    private bool _isEnabledSkript = true, _isEnabledMenu = true;


    private void Awake()
    {        
        GlobalEventManager.Event_StartGame += IsEnabled;
        GlobalEventManager.Event_FinishGame += IsEnabled;

        Deactivate_Menu_Pause();
        IsEnabled();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isEnabledMenu) { Activate_Menu_Pause(); }
            else { Deactivate_Menu_Pause(); }
        }
    }

    public void Activate_Menu_Pause()
    {
        Time.timeScale = 0f;
        _isEnabledMenu = true;
        _menu_Pause_Parrent.SetActive(true);
    }

    public void Deactivate_Menu_Pause()
    {
        Time.timeScale = 1f;
        _isEnabledMenu = false;
        _menu_Pause_Parrent.SetActive(false);
    }

    private void IsEnabled()
    {
        _isEnabledSkript = !_isEnabledSkript;
        gameObject.SetActive(_isEnabledSkript);
    }
}
