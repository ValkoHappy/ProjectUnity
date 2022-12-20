using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject _point;

    private Animator _animator;
    private int CheckpointKash = Animator.StringToHash("Checkpoint");

    public GameObject Point => _point;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartAnimation()
    {
        _animator.Play(CheckpointKash);
    }
}
