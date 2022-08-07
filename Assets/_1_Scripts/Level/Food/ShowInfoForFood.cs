using UnityEngine;
using TMPro;

namespace Level.Food
{
    public class ShowInfoForFood : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _textMesh;

        private void Start() =>_textMesh.text = GetComponent<Food>().NumberOfLivesRestored.ToString();      

    }
}