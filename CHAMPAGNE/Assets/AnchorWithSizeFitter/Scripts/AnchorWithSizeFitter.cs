using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(RectTransform))]
public class AnchorWithSizeFitter : MonoBehaviour
{
    private RectTransform _rectTransform;
    private RectTransform _parent;

    private Vector2 _parentRectSize;
    private Vector2 _rectSize;
    private Vector2 _offset;

    public void OnSetAnchores()
    {
        Initilization();
        SetCenterAnchor();

        _offset = _rectTransform.anchoredPosition / 2 / 100;

        _rectTransform.anchorMax = new Vector2(
           0.5f + ((float)_rectSize.x / (float)_parentRectSize.x) / 2 + _offset.x,
           0.5f + ((float)_rectSize.y / (float)_parentRectSize.y) / 2 + _offset.y);

        _rectTransform.anchorMin = new Vector2(
            0.5f - ((float)_rectSize.x / (float)_parentRectSize.x) / 2 + _offset.x,
            0.5f - ((float)_rectSize.y / (float)_parentRectSize.y) / 2 + _offset.y);

        _rectTransform.offsetMax = Vector2.zero;
        _rectTransform.offsetMin = Vector2.zero;
    }
    private void Initilization()
    {
        _parent = transform.parent.GetComponent<RectTransform>();
        _rectTransform = GetComponent<RectTransform>();
        _rectSize = _rectTransform.rect.size;
        _parentRectSize = _parent.rect.size;
    }
    private void SetCenterAnchor()
    {
        _rectTransform.sizeDelta = _rectSize;
        var position = _rectTransform.localPosition;

        _rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        _rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        _rectTransform.localPosition = position;
    }
}
