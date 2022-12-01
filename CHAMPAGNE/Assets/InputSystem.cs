using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputSystem : 
    MonoBehaviour,
    IPointerDownHandler,
    IPointerExitHandler,
    IDragHandler
{
    private InputData _data;
    private Action<InputData> _inputDataAction;

    private void Awake()
    {
        _data = new InputData();
    }

    public void Reg(Action<InputData> action)
    {
        _inputDataAction += action;
    }

    public void UnReg(Action<InputData> action)
    {
        _inputDataAction -= action;
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        _data.Drag = true;
        _inputDataAction?.Invoke(_data);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _data.Drag = false;
        _inputDataAction?.Invoke(_data);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _data.CurrentPosition = eventData.position;
        _data.Distance = Vector3.Distance(
            _data.StartPosition,
            _data.CurrentPosition);
        _data.Direction = (_data.StartPosition - _data.CurrentPosition).normalized;
        _inputDataAction?.Invoke(_data);
    }
}
