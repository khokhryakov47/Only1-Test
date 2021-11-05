using UnityEngine;

[System.Serializable]
public class SmoothPathPoint
{
    [SerializeField] private float _number;
    [SerializeField] private float _transitDuration;

    public float Number => _number;
    public float TransitDuration => _transitDuration;
}