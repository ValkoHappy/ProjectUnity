using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GostEnemy : MonoBehaviour
{
    [SerializeField] private Vector3[] _points;
    [SerializeField] private int _duration;
    [SerializeField] private float _turningTimeToAbject = 0.01f;
    [SerializeField] private int _numberOfRepetitions = -1;

    private void Start()
    {
        Tween tween = transform.DOPath(_points, _duration, PathType.CatmullRom, PathMode.Sidescroller2D).SetOptions(true).SetLookAt(_turningTimeToAbject);

        tween.SetEase(Ease.Linear).SetLoops(_numberOfRepetitions);
    }
}
