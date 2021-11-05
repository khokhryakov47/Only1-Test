using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CannonMuzzle : MonoBehaviour
{
    [SerializeField] private Transform _projectilePlace;
    [SerializeField] private float _installationDuration;
    [SerializeField] private float _releaseDuration;

    private Projectile _projectile;
    private Collider _collider;

    public Projectile Projectile => _projectile;

    public event UnityAction ProjectileInstalled;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Projectile projectile))
        {
            _projectile = projectile;
            _projectile.transform.DOMove(_projectilePlace.position, _installationDuration);
            _projectile.Fixate();
            ProjectileInstalled?.Invoke();
        }
    }

    public void ReleaseProjectile()
    {
        StartCoroutine(DisableCollider(_releaseDuration));
    }

    private IEnumerator DisableCollider(float releaseDuration)
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(releaseDuration);
        _collider.enabled = true;
    }
}