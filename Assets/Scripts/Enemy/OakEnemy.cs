using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OakEnemy : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _timer;

    private float _time;
    private Animator _animator;
    private int AttackKash = Animator.StringToHash("Attack");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _timer)
        {
            _animator.SetTrigger(AttackKash);
            Shoot(_shootPoint);
            _time = 0;
        }
    }

    public void Shoot(Transform shootPoint)
    {
        Instantiate(_bullet, shootPoint.position, Quaternion.identity);
    }
}
