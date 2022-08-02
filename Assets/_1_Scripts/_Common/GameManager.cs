using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;
using Player;

public class GameManager : MonoBehaviour
{
    [SerializeField] private byte _numberLevel;
    [SerializeField] private bool _isEndlessLevel = false;
    
    private GameObject _game, _level, _player;

    private void Start()
    {
        StartGame();
    }


    private void StartGame()
    {
        _game = new GameObject("Game");
        _level = new GameObject("Level"); _level.transform.parent = _game.transform;
        _level.AddComponent<Levels>();
        _level.GetComponent<Levels>().Construct(_level, _numberLevel, _isEndlessLevel);

        _player = new GameObject("Player"); _player.transform.parent = _game.transform;
        _player.AddComponent<PlayerBuilder>();
        _player.GetComponent<PlayerBuilder>().Construct(_player, new Vector3 (0,1.1f,-25));
    }

 











    private void FinishGame()
    {
        Destroy(_game);
    }

    private void RestartGame()
    {   
        FinishGame();
        StartGame();
    }




}
