using UnityEngine;
using TMPro;

namespace Player.Character.Snake
{

    public class ShowInfoForHealth : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _textMesh;

        public void ShowInfo(int info)
        {
            _textMesh.text = info.ToString();
        }
    }
}