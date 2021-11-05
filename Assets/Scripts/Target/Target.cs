using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    private Block[] _blocks;

    public event UnityAction<Target> Broken;

    private void Awake()
    {
        _blocks = GetComponentsInChildren<Block>();
    }

    private void OnEnable()
    {
        foreach (var block in _blocks)
        {
            block.Collided += OnCollided;
        }
    }

    private void OnDisable()
    {
        foreach (var block in _blocks)
        {
            block.Collided -= OnCollided;
        }
    }

    private void OnCollided()
    {
        Broken?.Invoke(this);
        foreach (var block in _blocks)
        {
            block.StartFall();
        }
    }
}