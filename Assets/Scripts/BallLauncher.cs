using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private LaunchPreview _launchPreview;
    private UImanager _uImanager;
    private List<Ball> _balls = new List<Ball>();
    public static int ballsReady = 0;

    [SerializeField] private Ball ballPrefab;
    private BlockSpawner blockSpawner;
    public bool isCanShoot = true;

    private void Awake()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
        _launchPreview = GetComponent<LaunchPreview>();
        _uImanager = GetComponent<UImanager>();
        ballsReady = PlayerPrefs.BallsReady;
        CreateBall();
    }

    public void ReturnBall()
    {
        ballsReady++;
        if (ballsReady == _balls.Count)
        {
            _uImanager.ChangeRounds();
            blockSpawner.SpawnRowOfBlocks();
            CreateBall();
            isCanShoot = true;
        }
    }

    private void CreateBall()
    {
        var ball = Instantiate(ballPrefab);
        _balls.Add(ball);
        ballsReady++;
    }

    private void Update()
    {
        // умножаю на -10 из-за того что камера на -10 по Z, а шар на 0 по Z (чтобы не телепортался в Z -10)
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10; 
        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(worldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }


    private IEnumerator LaunchBalls()
    {
        Vector3 direction = endPosition - startPosition;
        direction.Normalize();
        if (direction.y >= -0.1f)
        {
            direction.y = -0.1f;
        }
        Debug.Log(direction);
        foreach (var ball in _balls)
        {
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);


            ballsReady -= 1;

            yield return new WaitForSeconds(0.1f);
            isCanShoot = false;
        }
    }

    private void StartDrag(Vector3 worldPosition)
    {
        startPosition = worldPosition;
        _launchPreview.SetStartPoint(transform.position);
    }

    private void ContinueDrag(Vector3 worldPosition)
    {
        endPosition = worldPosition;
        Vector3 direction = endPosition - startPosition;

        _launchPreview.SetEndPoint(transform.position - direction);
    }

    private void EndDrag()
    {
        if (isCanShoot)
            StartCoroutine(LaunchBalls());
    }
}
