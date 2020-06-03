using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float moveSpeed = 10f;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * moveSpeed;
        

    }

    private void FixedUpdate()
    {
        //Left edge detection                                                            //Right edge detection
        if (transform.position.x <= _camera.ScreenToWorldPoint(new Vector2(0, 0)).x || transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x)
        {
            Vector2 oldVel = _rigidbody2D.velocity;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.velocity = oldVel * new Vector2(-1, 1);
        }

        //Top detection
        if(transform.position.y >= _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y)
        {
            Vector2 oldVel = _rigidbody2D.velocity;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.velocity = oldVel * new Vector2(1, -1);
        }
    }
}
