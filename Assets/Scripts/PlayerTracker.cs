using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _yOffset;

    private void Update()
    {
        transform.position = new Vector3(0, _player.transform.position.y - _yOffset, _player.transform.position.z - 1);
    }
}
