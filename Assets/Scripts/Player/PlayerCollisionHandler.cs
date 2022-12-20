using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player), typeof(PlayerMover))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleDie;

    private Player _player;
    private PlayerMover _playerMover;

    private void Start()
    {
        _player = GetComponent<Player>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Danger danger) || collision.TryGetComponent(out Bullet bullet) || collision.TryGetComponent(out GostEnemy gostEnemy))
        {
            Instantiate(_particleDie, transform.position, transform.rotation);
            _playerMover.TurnOffControl();
            _player.Die();
        }

        if (collision.TryGetComponent(out Coin coin))
        {
            _player.AddCoin();
            coin.Die();
        }

        if (collision.TryGetComponent(out Checkpoint checkpoint))
        {
                _playerMover.SetNewStartPositon(checkpoint.Point.transform.position);
                checkpoint.StartAnimation();
        }
    }
}
