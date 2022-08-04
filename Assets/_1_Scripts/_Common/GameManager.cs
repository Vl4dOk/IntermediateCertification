using UnityEngine;
using Level;
using Player;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Menu_Levels _menu_Levels;
    private int _numberLevel = 1;
    private bool _isEndlessLevel = false;







    private GameObject _game, _level, _player;
    private bool _isGameRunning = false;

    private void DataCollection()
    {
        _numberLevel = _menu_Levels.CurrentLevel;
        _isEndlessLevel = _menu_Levels.IsEndlessLevel;
        //_numberCharacter
        //
    }

    public void StartGame()
    {
        if (_isGameRunning == true)
            return;
        
        _game = new GameObject("Game");
        _level = new GameObject("Level"); _level.transform.parent = _game.transform;
        _level.AddComponent<Levels>();
        _level.GetComponent<Levels>().Construct(_level, _numberLevel, _isEndlessLevel);

        _player = new GameObject("Player"); _player.transform.parent = _game.transform;
        _player.AddComponent<PlayerBuilder>();
        _player.GetComponent<PlayerBuilder>().Construct(_player, new Vector3 (0,1.1f,-25));
        _isGameRunning = true;
    }

    public void FinishGame()
    {
        Destroy(_game);
        _isGameRunning = false;
    }

    public void RestartGame()
    {   
        FinishGame();
        StartGame();
    }


    public void NextLevel()
    {
        FinishGame();

        _numberLevel++;

        StartGame();
    }


}
