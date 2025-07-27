using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public class ButtonHoverEvent : UnityEvent { }

public class CookieRunButton : Button, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Extended Button Settings")]
    [SerializeField] private float _doubleClickTime = 0.3f;
    [SerializeField] private float _hoverTime = 0.1f;
    [SerializeField] private bool _isDraggable = true;
    [SerializeField] private bool _isClickable = true;
    [SerializeField] private bool _isHoverable = true;

    public ButtonClickedEvent OnLeftClick;
    public ButtonClickedEvent OnRightClick;
    public ButtonClickedEvent OnDoubleClick;
    public ButtonHoverEvent OnHoverEnter;
    public ButtonHoverEvent OnHoverExit;

    private float _lastClickTime;
    private bool _isHovered;
    private bool _isDragging;
    private Vector2 _dragStartPosition;
    private Coroutine _clickCoroutine;

    protected override void Start()
    {
        base.Start();

        OnLeftClick ??= new ButtonClickedEvent();
        OnRightClick ??= new ButtonClickedEvent();
        OnDoubleClick ??= new ButtonClickedEvent();
        OnHoverEnter ??= new ButtonHoverEvent();
        OnHoverExit ??= new ButtonHoverEvent();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (IsActive() == false || IsInteractable() == false || _isDragging || _isClickable == false)
        {
            return;
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (OnRightClick != null)
            {
                OnRightClick.Invoke();
            }
            return;
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (_clickCoroutine != null)
            {
                StopCoroutine(_clickCoroutine);
                _clickCoroutine = null;

                if (OnDoubleClick != null)
                {
                    OnDoubleClick.Invoke();
                }
            }
            else
            {
                _clickCoroutine = StartCoroutine(DelayedLeftClick());
            }
        }
    }

    private IEnumerator DelayedLeftClick()
    {
        yield return new WaitForSecondsRealtime(_doubleClickTime);

        _clickCoroutine = null;
        OnLeftClick?.Invoke();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

        if (IsActive() == false || IsInteractable() == false || _isHoverable == false)
        {
            return;
        }

        if (_isHovered == false)
        {
            _isHovered = true;
            StartCoroutine(HoverCoroutine(true));
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);

        if (_isHovered)
        {
            _isHovered = false;
            StartCoroutine(HoverCoroutine(false));
        }
    }

    private IEnumerator HoverCoroutine(bool entering)
    {
        yield return new WaitForSecondsRealtime(_hoverTime);

        if (entering && _isHovered)
        {
            OnHoverEnter?.Invoke();
        }
        else if (entering == false && _isHovered == false)
        {
            OnHoverExit?.Invoke();
        }
    }
}