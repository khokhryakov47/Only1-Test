using DG.Tweening;
using UnityEngine;

public class EndLevelScreen : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private CanvasGroup _victoryScreen;
    [SerializeField] private CanvasGroup _defeatScreen;
    [SerializeField] private float _fadeDuration;

    private void OnEnable()
    {
        _level.Defeat += OnDefeat;
        _level.Victory += OnVictory;
    }

    private void OnDisable()
    {
        _level.Defeat -= OnDefeat;
        _level.Victory -= OnVictory;
    }

    private void OnDefeat()
    {
        OpenPanel(_defeatScreen);
    }

    private void OnVictory()
    {
        OpenPanel(_victoryScreen);
    }

    private void OpenPanel(CanvasGroup group)
    {
        group.blocksRaycasts = true;
        group.DOFade(1, _fadeDuration);
    }
}