using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Event
{
    public class Menu_Victory : MonoBehaviour
    {
        [SerializeField] private GameObject _menu_Victory;

        private void Awake()
        {
            if (_menu_Victory == null) { _menu_Victory = gameObject; }
            GlobalEventManager.Event_PlayerOnFinish += Activate_Menu_Victory;

            Deactivate_Menu_Victory();
        }



        public void Activate_Menu_Victory()
        {
            _menu_Victory.SetActive(true);
        }
        public void Deactivate_Menu_Victory()
        {
            _menu_Victory.SetActive(false);
        }





    }
}