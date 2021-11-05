using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _explotionRadius;
    [SerializeField] private float _stoppedMagnitude;

    private Rigidbody _rigidbody;

    public Vector3 Velocity => _rigidbody.velocity;

    private const float StopCheckDelay = 0.5f;

    public event UnityAction<Projectile> Stopped;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Fixate()
    {
        _rigidbody.isKinematic = true;
    }

    public void Push(Vector3 force)
    {
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(force, ForceMode.Impulse);
        StartCoroutine(StopCheck());
    }

    private IEnumerator StopCheck()
    {
        yield return new WaitForFixedUpdate();
        while (_rigidbody.velocity.magnitude > _stoppedMagnitude)
        {
            yield return null;
        }
        Stopped?.Invoke(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out Block block))
        {
            block.ExplosionPush(_rigidbody.velocity.magnitude, _explotionRadius);
        }
    }
}