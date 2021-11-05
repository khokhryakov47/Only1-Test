using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class CannonCamera : DollyCameraMover
{
    [Header("Points")]
    [SerializeField] private SmoothPathPoint _topDownPoint;
    [SerializeField] private SmoothPathPoint _behindPoint;

    [SerializeField] private CannonMuzzle _muzzle;
    [SerializeField] private ProjectileStorage _storage;

    public event UnityAction TopDownInstalled;
    public event UnityAction BehindInstalled;

    private void OnEnable()
    {
        _muzzle.ProjectileInstalled += OnProjectileInstalled;
        _storage.ProjectileStopped += OnProjectileStopped;
    }

    private void OnDisable()
    {
        _muzzle.ProjectileInstalled -= OnProjectileInstalled;
        _storage.ProjectileStopped -= OnProjectileStopped;
    }

    private void OnProjectileStopped()
    {
        MoveTo(_topDownPoint);
        TopDownInstalled?.Invoke();
    }

    private void OnProjectileInstalled()
    {
        MoveTo(_behindPoint);
        BehindInstalled?.Invoke();
    }
}