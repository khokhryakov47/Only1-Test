using UnityEngine;
using UnityEngine.Events;

public class LevelConfigurator : MonoBehaviour
{
    [SerializeField] private LevelConfiguration _levelConfiguration;
    [SerializeField] private TargetSpawner _targetSpawner;
    [SerializeField] private ProjectileSpawner _projectileSpawner;

    public event UnityAction<Target> TargetSpawned;

    private void Start()
    {
        Target spawnedTarget = _targetSpawner.Spawn(GetRandomTarget(_levelConfiguration.Targets));
        _projectileSpawner.StartSpawn(_levelConfiguration.ProjectileCount);
        TargetSpawned?.Invoke(spawnedTarget);
    }

    private Target GetRandomTarget(Target[] targets)
    {
        return _levelConfiguration.Targets[Random.Range(0, _levelConfiguration.Targets.Length)];
    }
}