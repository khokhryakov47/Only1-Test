using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PowerScale : MonoBehaviour
{
    [SerializeField] private PowerScaleView _view;
    private Coroutine _accumulateJob;

    public event UnityAction<float> PowerAccumulated;

    public void StartAccumulate()
    {
        _accumulateJob = StartCoroutine(AccumulatePower());
    }

    private IEnumerator AccumulatePower()
    {
        Touch touch;
        float touchId = -1;
        while (true)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchId = touch.fingerId;
                    _view.StartFilling();
                }
                else if (touch.phase == TouchPhase.Ended && touchId == touch.fingerId)
                {
                    _view.StopFilling();
                    float powerMultiplier = GetPowerMultiplier(_view.MaxValue, _view.Value);
                    PowerAccumulated?.Invoke(powerMultiplier);
                    yield break;
                }

            }
            yield return null;
        }
    }

    private float GetPowerMultiplier(float maxValue, float sliderValue)
    {
        return maxValue - Mathf.Abs(sliderValue);
    }
}