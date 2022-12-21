using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _tapForcePlus;

    private Vector2 _startPosition;
    private Rigidbody2D _rigidbody;
    private bool _jumpSide = true;
    private bool _collisionWithAnObject = true;
    private int _doubleJump;

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        TurnOffControl();
    }

    private void Update()
    {
        if(_collisionWithAnObject == true)
        {
            if (_doubleJump != 2)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _doubleJump++;
                    _rigidbody.isKinematic = false;
                    _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
                    if (_jumpSide == true)
                    {
                        _rigidbody.velocity = new Vector2(_speed, 0);
                        _jumpSide = false;
                    }
                    else if (_jumpSide == false)
                    {
                        _rigidbody.velocity = new Vector2(-_speed, 0);
                        _jumpSide = true;
                    }
                }
            }
            else
            {
                _doubleJump = 0;
                _collisionWithAnObject = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 vector2 = transform.position;
        if (collision.TryGetComponent(out Wall wall))
        {
            transform.position = vector2;
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.isKinematic = true;
            _doubleJump = 0;
            _collisionWithAnObject = true;
        }
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.isKinematic = true;
        _doubleJump = 0;
        _collisionWithAnObject = true;
    }

    public void SetNewStartPositon(Vector2 vector2)
    {
        _startPosition = vector2;
    }

    public void TurnOffControl()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector2.zero;
        _collisionWithAnObject = false;
    }
}
