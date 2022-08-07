using UnityEngine;
using Level;
using Player;
using Event;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Menu_Levels _menu_Levels;
    private int _numberLevel;
    private bool _isEndlessLevel;


    private GameObject _game, _level, _player;
    private bool _isGameRunning = false;

    public void StartGame()
    {
        if (_isGameRunning)
            return;

        DataCollection();

        _game = new GameObject("Game");
        _level = new GameObject("Level"); _level.transform.parent = _game.transform;
        _level.AddComponent<Levels>();
        _level.GetComponent<Levels>().Construct(_level, _numberLevel, _isEndlessLevel);

        _player = new GameObject("Player"); _player.transform.parent = _game.transform;
        _player.AddComponent<PlayerBuilder>();
        _player.GetComponent<PlayerBuilder>().Construct(_player, new Vector3 (0,1.1f,-25));
        _isGameRunning = true;
        GlobalEventManager.Event_StartGame.Invoke();
    }

    public void FinishGame()
    {
        Destroy(_game);
        _isGameRunning = false;
        GlobalEventManager.Event_FinishGame.Invoke();
    }

    public void RestartGame()
    {   
        FinishGame();       
        StartGame();
    }

    public void NextLevel()
    {
        FinishGame();
        _menu_Levels.CurrentLevel++;
        StartGame();
    }

    private void DataCollection()
    {
        _numberLevel = _menu_Levels.CurrentLevel;
        _isEndlessLevel = _menu_Levels.IsEndlessLevel;
    }
}
