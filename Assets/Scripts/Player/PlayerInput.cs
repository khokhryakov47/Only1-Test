using UnityEngine;

[RequireComponent(typeof(ProjectileDrag))]
[RequireComponent(typeof(PowerScale))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CannonCamera _camera;

    private ProjectileDrag _projectileDrag;
    private PowerScale _powerScale;

    private void Awake()
    {
        _powerScale = GetComponent<PowerScale>();
        _projectileDrag = GetComponent<ProjectileDrag>();
    }

    private void OnEnable()
    {
        _camera.BehindInstalled += OnBehindInstalled;
        _camera.TopDownInstalled += OnTopDownInstalled;
    }

    private void OnDisable()
    {
        _camera.BehindInstalled -= OnBehindInstalled;
        _camera.TopDownInstalled -= OnTopDownInstalled;
    }

    private void OnBehindInstalled()
    {
        _powerScale.StartAccumulate();
    }

    private void OnTopDownInstalled()
    {
        _projectileDrag.StartDrag();
    }
}