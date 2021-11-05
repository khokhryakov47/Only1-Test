using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public event UnityAction Collided;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void StartFall()
    {
        _rigidbody.isKinematic = false;
    }

    public void ExplosionPush(float force, float radius)
    {
        _rigidbody.AddExplosionForce(force, transform.position, radius);
        Collided?.Invoke();
    }
}