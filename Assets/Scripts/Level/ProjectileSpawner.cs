using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Projectile _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnDelay;

    public event UnityAction<Projectile> Spawned;

    public void StartSpawn(int count)
    {
        StartCoroutine(Spawn(count));
    }

    private IEnumerator Spawn(int count)
    {
        WaitForSeconds spawnDelay = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < count; i++)
        {
            Projectile spawnedProjectile = Instantiate(_template, _spawnPoint.position, Quaternion.identity);
            Spawned?.Invoke(spawnedProjectile);
            yield return spawnDelay;
        }
    }
}
