using UnityEngine;

public class BallReturn : MonoBehaviour
{
    private BallLauncher ballLauncher;

    private void Awake()
    {
        ballLauncher = FindObjectOfType<BallLauncher>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballLauncher.ReturnBall();
        collision.collider.gameObject.SetActive(false);
       
    }
}
