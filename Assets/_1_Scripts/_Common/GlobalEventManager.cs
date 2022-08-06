using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public delegate void StartGame();
    public static StartGame Event_StartGame = null;


    public delegate void PlayerOnFinish();
    public static PlayerOnFinish Event_PlayerOnFinish = null;


    public delegate void FinishGame();
    public static StartGame Event_FinishGame = null;





}
