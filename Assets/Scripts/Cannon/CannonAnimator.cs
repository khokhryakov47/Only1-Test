using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Cannon))]
public class CannonAnimator : MonoBehaviour
{
    private Animator _self;
    private Cannon _cannon;

    private const string ShotTriggetParameter = "Shot";

    private void Awake()
    {
        _self = GetComponent<Animator>();
        _cannon = GetComponent<Cannon>();
    }

    private void OnEnable()
    {
        _cannon.Shot += OnShot;
    }

    private void OnDisable()
    {
        _cannon.Shot -= OnShot;
    }

    private void OnShot()
    {
        _self.SetTrigger(ShotTriggetParameter);
    }
}