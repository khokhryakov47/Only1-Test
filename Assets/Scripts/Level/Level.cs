using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LevelConfigurator))]
public class Level : MonoBehaviour
{
    [SerializeField] private ProjectileStorage _projectileStorage;
    [SerializeField] private CannonCamera _cannonCamera;

    private LevelConfigurator _configurator;
    private Target _target;

    public event UnityAction Victory;
    public event UnityAction Defeat;

    private void Awake()
    {
        _configurator = GetComponent<LevelConfigurator>();
    }

    private void OnEnable()
    {
        _configurator.TargetSpawned += OnTargetSpawned;
        _projectileStorage.Emptied += OnEmptied;
    }

    private void OnDisable()
    {
        _configurator.TargetSpawned -= OnTargetSpawned;
        _projectileStorage.Emptied -= OnEmptied;
    }

    private void OnTargetSpawned(Target target)
    {
        target.Broken += OnBroken;
    }

    private void OnBroken(Target target)
    {
        target.Broken -= OnBroken;
        Victory?.Invoke();
        Complete();
    }

    private void OnEmptied()
    {
        Defeat?.Invoke();
        Complete();
    }

    private void Complete()
    {
        _cannonCamera.enabled = false;
        enabled = false;
        enabled = false;
    }
}