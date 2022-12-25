using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleDie;

    private PlayerMover _playerMover;

    public UnityEvent CollideWithDanger;
    public UnityEvent CollideWithCoin;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Danger danger) || collision.TryGetComponent(out Bullet bullet) || collision.TryGetComponent(out GostEnemy gostEnemy))
        {
            Instantiate(_particleDie, transform.position, transform.rotation);
            CollideWithDanger?.Invoke();
        }

        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Die();
            CollideWithCoin?.Invoke();
        }

        if (collision.TryGetComponent(out Checkpoint checkpoint))
        {
            _playerMover.SetNewStartPositon(checkpoint.Point.transform.position);
            checkpoint.StartAnimation();
        }
    }
}
