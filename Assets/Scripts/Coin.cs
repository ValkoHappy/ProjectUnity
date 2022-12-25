using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _profit;
    [SerializeField] private ParticleSystem _particle;

    public int Profit => _profit;

    public void Die()
    {
        Instantiate(_particle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
