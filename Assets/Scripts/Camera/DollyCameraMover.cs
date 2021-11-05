using Cinemachine;
using UnityEngine;
using DG.Tweening;

public class DollyCameraMover : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private CinemachineSmoothPath _path;

    private CinemachineTrackedDolly _trackedDolly;

    private void Awake()
    {
        _trackedDolly = _camera.GetCinemachineComponent<CinemachineTrackedDolly>();

        if (_trackedDolly == null)
            throw new System.Exception("Virtual camera body type must be Tracked Dolly");
    }

    protected void MoveTo(SmoothPathPoint point)
    {
        CheckCorrect(point);
        DOTween.To(() => _trackedDolly.m_PathPosition, x => _trackedDolly.m_PathPosition = x, point.Number, point.TransitDuration);
    }

    private void CheckCorrect(SmoothPathPoint smoothPathPoint)
    {
        if (smoothPathPoint.Number < 0 || smoothPathPoint.Number > _path.PathLength)
            throw new System.Exception("Point outside the path");
    }
}