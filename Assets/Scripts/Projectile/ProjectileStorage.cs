using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileStorage : MonoBehaviour
{
    [SerializeField] private ProjectileSpawner _spawner;

    private List<Projectile> _projectiles;

    public event UnityAction ProjectileStopped;
    public event UnityAction Emptied;

    private void Awake()
    {
        _projectiles = new List<Projectile>();
    }

    private void OnEnable()
    {
        _spawner.Spawned += OnSpawned;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= OnSpawned;
    }

    private void OnSpawned(Projectile projectile)
    {
        _projectiles.Add(projectile);
        projectile.Stopped += OnStopped;
        projectile.transform.parent = transform;
    }

    private void OnStopped(Projectile projectile)
    {
        projectile.Stopped -= OnStopped;
        _projectiles.Remove(projectile);
        Destroy(projectile.gameObject);

        if(_projectiles.Count == 0)
        {
            Emptied?.Invoke();
        }

        ProjectileStopped?.Invoke();
    }
}