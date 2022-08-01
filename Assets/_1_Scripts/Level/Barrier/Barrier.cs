using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Character.Snake;

public class Barrier : MonoBehaviour
{
    public byte _health;

    [SerializeField] private float _timeBetweenContacts = 0.3f;
    [SerializeField] private ShowInfoForBarrier _showHealthInfo;
    private float _isContact = 0;


    private void Start() => _showHealthInfo = GetComponent<ShowInfoForBarrier>();
    



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out SnakeHealth snakeHealth))
        {
            snakeHealth.RemoveHealth();
            _health--;
            _showHealthInfo.ShowInfo(_health);

            if (_health <= 0)
            { Destroy(gameObject); }

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out SnakeHealth snakeHealth))
        {
            _isContact += Time.deltaTime;

            if(_isContact >= _timeBetweenContacts)
            {
                _health--;
                _showHealthInfo.ShowInfo(_health);
                snakeHealth.RemoveHealth();
                _isContact = 0;
            }
        }
        if (_health <= 0)
        { Destroy(gameObject);         
        }
    }

    private void OnCollisionExit(Collision collision) => _isContact = 0;
}
