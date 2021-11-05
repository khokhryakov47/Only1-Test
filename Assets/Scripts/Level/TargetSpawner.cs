using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    public Target Spawn(Target target)
    {
        return Instantiate(target, _spawnPoint);
    }
}