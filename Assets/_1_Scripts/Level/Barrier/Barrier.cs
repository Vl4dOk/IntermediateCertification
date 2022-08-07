using UnityEngine;

using Player.Character.Snake;

public class Barrier : MonoBehaviour
{
    public short Health;
    private readonly short _maxIncrease = 20;

    [SerializeField] private float _timeBetweenContacts = 0.3f;
    [SerializeField] private ShowInfoForBarrier _showHealthInfo;
    private float _isContact = 0;


    private void Start() 
    {
        Health = (short)(Health + Random.Range(1, _maxIncrease));
        _showHealthInfo = GetComponent<ShowInfoForBarrier>();    
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out SnakeHealth snakeHealth))
        {
            snakeHealth.RemoveHealth();
            Health--;
            _showHealthInfo.ShowInfo(Health);

            if (Health <= 0)
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
                Health--;
                _showHealthInfo.ShowInfo(Health);
                snakeHealth.RemoveHealth();
                _isContact = 0;
            }
        }
        if (Health <= 0)
        { Destroy(gameObject);}
    }

    private void OnCollisionExit(Collision collision) => _isContact = 0;
}
