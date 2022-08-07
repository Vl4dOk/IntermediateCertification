using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBuilder : MonoBehaviour
    {
        [HideInInspector] public GameObject Player;
        private GameObject _character;
        private GameObject _camera;


        public void Construct(GameObject player, Vector3 characterPosition)
        {
            Player = player;
            AddCharacter(characterPosition);
            AddCamera();
        }

        private void AddCharacter(Vector3 position)
        {
            _character = Instantiate((GameObject)Resources.Load("Prefabs/Player/Character/Snake/Snake(Head)/SnakeHead"), position,Quaternion.identity,Player.transform) ;
        }

        private void AddCamera()
        {
            _camera = Instantiate((GameObject)Resources.Load("Prefabs/Player/Camera/Camera"), Player.transform);
            _camera.GetComponent<MyCameraController>().Target = _character.transform;
        }
    }
}
