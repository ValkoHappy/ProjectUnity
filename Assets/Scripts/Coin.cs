using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    public void Die()
    {
        Instantiate(_particle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
