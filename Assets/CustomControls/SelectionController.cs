using System.Collections;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] _selectionPoints;
    [SerializeField]
    private RectTransform _selector;

    [SerializeField]
    private float _animationDuration;

    private IEnumerator _coroutine;

    private int _currentSelectionIndex;

    public void SelectNext()
    {
        if (_currentSelectionIndex < _selectionPoints.Length)
            _currentSelectionIndex++;

        SelectCurrent();
    }

    public void SelectLast()
    {
        if (_currentSelectionIndex > 0)
            _currentSelectionIndex--;

        SelectCurrent();
    }

    private void SelectCurrent()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        float targetPosition = _selectionPoints[_currentSelectionIndex].anchoredPosition.y;

        _coroutine = SelectionAnimation(targetPosition);

        StartCoroutine(_coroutine);
    }

    private IEnumerator SelectionAnimation(float targetPosY)
    {
        float currentPosY   = _selector.anchoredPosition.y;
        float time          = 0;

        while (time < _animationDuration)
        {
            float newPosY = Mathf.Lerp(currentPosY, targetPosY, time / _animationDuration);

            _selector.anchoredPosition = new(_selector.anchoredPosition.x, newPosY);

            time += Time.deltaTime;

            yield return null;
        }

        _selector.anchoredPosition = new(_selector.anchoredPosition.x, targetPosY);

        yield break;
    }
}