using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowInfoForBarrier : MonoBehaviour
{
    [SerializeField] private TextMeshPro[] _textMesh;
    private short _health;

    void Start()
    {
        _health = GetComponent<Barrier>()._health;

        for (int i = 0; i < _textMesh.Length; i++)
        {
            _textMesh[i].text = _health.ToString();
        }
    }


    public void ShowInfo(short info)
    {
        for (int i = 0; i < _textMesh.Length; i++)
        {
            _textMesh[i].text = info.ToString();
        }
    }



}
