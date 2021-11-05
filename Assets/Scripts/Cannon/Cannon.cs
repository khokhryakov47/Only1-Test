using UnityEngine;
using UnityEngine.Events;

public class Cannon : MonoBehaviour
{
    [SerializeField] private PowerScale _powerScale;
    [SerializeField] private float _maxPower;
    [SerializeField] private CannonMuzzle _muzzle;

    public event UnityAction Shot;

    private void OnEnable()
    {
        _powerScale.PowerAccumulated += OnPowerAccumulated;
    }

    private void OnDisable()
    {
        _powerScale.PowerAccumulated -= OnPowerAccumulated;
    }

    private void OnPowerAccumulated(float powerMultiplier)
    {
        Shoot(powerMultiplier * _maxPower);
    }

    private void Shoot(float power)
    {
        _muzzle.ReleaseProjectile();
        _muzzle.Projectile.Push(Vector3.forward * power);
        Shot?.Invoke();
    }
}