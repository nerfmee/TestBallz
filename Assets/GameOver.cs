
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool _gameOver;
    [SerializeField] private GameObject GameOverPanel;
    private void OnCollisionStay2D(Collision2D other)
    {
        _gameOver = true;
        GameOverPanel.SetActive(true);
    }
}
