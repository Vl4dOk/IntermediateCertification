using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Event
{
    public class Menu_Victory : MonoBehaviour
    {


        private void Awake()
        {
            Deactivate_Menu_Victory();

        }



        public void Activate_Menu_Victory()
        {
            gameObject.SetActive(true);
            GlobalEventManager.Event_PlayerOnFinish -= Activate_Menu_Victory;
        }
        public void Deactivate_Menu_Victory()
        {
            gameObject.SetActive(false);
            GlobalEventManager.Event_PlayerOnFinish += Activate_Menu_Victory;
        }





    }
}