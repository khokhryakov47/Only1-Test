using UnityEngine;

[CreateAssetMenu(fileName = "New Level Config", menuName = "Create new Level Config", order = 41)]
public class LevelConfiguration : ScriptableObject
{
    [SerializeField] private Target[] _targets;
    [SerializeField] private int _projectileCount;

    public Target[] Targets => _targets;
    public int ProjectileCount => _projectileCount;
}