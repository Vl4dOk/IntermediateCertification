using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBuilder : MonoBehaviour
    {
        private GameObject _player;


        private GameObject _character;
        private GameObject _camera;


        public void Construct(GameObject player, Vector3 characterPosition)
        {
            _player = player;
            AddCharacter(characterPosition);
            AddCamera();
        }

        private void AddCharacter(Vector3 position)
        {
            _character = Instantiate((GameObject)Resources.Load("Prefabs/Player/Character/Snake/Snake(Head)/SnakeHead"), position,Quaternion.identity,_player.transform) ;
        }

        private void AddCamera()
        {
            _camera = Instantiate((GameObject)Resources.Load("Prefabs/Player/Camera/Camera"), _player.transform);
            _camera.GetComponent<MyCameraController>().Target = _character.transform;
        }
    }
}
