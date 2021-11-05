using System.Collections;
using UnityEngine;

public class ProjectileDrag : MonoBehaviour
{
    [SerializeField] private float _dragHeight;
    [SerializeField] private CannonMuzzle _muzzle;

    private Camera _camera;
    private Coroutine _dragJob;

    private void Awake()
    {
        _camera = Camera.main;
        StartDrag();
    }

    private void OnEnable()
    {
        _muzzle.ProjectileInstalled += OnProjectileInstalled;
    }

    private void OnDisable()
    {
        _muzzle.ProjectileInstalled -= OnProjectileInstalled;
    }

    public void StartDrag()
    {
        _dragJob = StartCoroutine(Drag());
    }

    private IEnumerator Drag()
    {
        Projectile projectile = null;
        Touch touch;

        while (true)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    projectile = TryTakeProjectile(touch.position);
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    projectile = null;
                }

                if (projectile != null)
                {
                    MoveProjectile(projectile, touch);
                }
            }

            yield return null;
        }
    }

    private Projectile TryTakeProjectile(Vector2 screenPosition)
    {
        Ray ray = _camera.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Projectile projectile))
            {
                return projectile;
            }
        }

        return null;
    }

    private void MoveProjectile(Projectile projectile, Touch touch)
    {
        Vector3 dragPosition = GetTouchWorldPosition(touch);
        dragPosition.y = _dragHeight;
        projectile.transform.position = dragPosition;
    }

    private Vector3 GetTouchWorldPosition(Touch touch)
    {
        Ray ray = _camera.ScreenPointToRay(touch.position);
        Plane plane = new Plane(Vector3.up, 0);

        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }

    private void OnProjectileInstalled()
    {
        StopCoroutine(_dragJob);
    }
}