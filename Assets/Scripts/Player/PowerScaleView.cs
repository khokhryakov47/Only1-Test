using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Slider))]
public class PowerScaleView : MonoBehaviour
{
    [SerializeField] private float _fadeDuration;
    [SerializeField] private float _feelDuration;

    private CanvasGroup _canvasGroup;
    private Slider _scale;
    private Sequence _filling;

    public float MaxValue => _scale.maxValue;
    public float Value => _scale.value;

    private void Start()
    {
        _scale = GetComponent<Slider>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _filling = DOTween.Sequence();
        _filling.Append(_scale.DOValue(_scale.maxValue, _feelDuration));
        _filling.Append(_scale.DOValue(_scale.minValue, _feelDuration));
        _filling.SetLoops(-1);
        _filling.Pause();
    }

    public void StartFilling()
    {
        _canvasGroup.DOFade(1, _fadeDuration);
        _canvasGroup.blocksRaycasts = true;
        _filling.Play();
    }

    public void StopFilling()
    {
        _canvasGroup.DOFade(0, _fadeDuration);
        _canvasGroup.blocksRaycasts = false;
        _filling.Pause();
    }
}