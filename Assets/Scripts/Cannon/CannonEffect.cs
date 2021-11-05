using UnityEngine;

public class CannonEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private Transform _spawnPoint;

    public void PlayShootEffect()
    {
        Instantiate(_shootEffect, _spawnPoint.position, Quaternion.identity);
    }
}
