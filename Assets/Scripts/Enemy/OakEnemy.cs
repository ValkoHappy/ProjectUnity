using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OakEnemy : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _waitForSecounds;

    private Animator _animator;
    private Coroutine _shoot;
    private int AttackKash = Animator.StringToHash("Attack");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        StartShoot();
    }

    private void StartShoot()
    {
        if (_shoot != null)
        {
            StopCoroutine(_shoot);
        }
        _shoot = StartCoroutine(Shoot());
    }

    public void CreateBullet(Transform shootPoint)
    {
        Instantiate(_bullet, shootPoint.position, Quaternion.identity);
    }

    private IEnumerator Shoot()
    {
        var waitForSecounds = new WaitForSeconds(_waitForSecounds);

        _animator.SetTrigger(AttackKash);
        CreateBullet(_shootPoint);

        yield return waitForSecounds;

        StartShoot();
    }
}
