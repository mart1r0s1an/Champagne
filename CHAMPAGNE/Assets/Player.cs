using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;

    private Camera _camera;
    private InputData _data;
    private void Awake()
    {
        _camera = Camera.main;
        _data = new InputData();
        _inputSystem.Reg(GetData);
    }


    private void Start()
    {
        
    }

    private bool locker;
    IEnumerator A()
    {
        if(locker)
            yield break;

        locker = true;
        
        Debug.Log("in");
        
        locker = false;
    }
    
    void b(Func<int, bool> func)
    {
        if (func.Invoke(10))
        {
            Debug.Log("11111111");
        }
    }

    private void GetData(InputData inputData)
    {
        _data = inputData;
    }
    private void Update()
    {
        var movePos = _camera.ScreenPointToRay(_data.CurrentPosition).origin;
        movePos = new Vector3(movePos.x, movePos.y);
        transform.position = Vector3.Lerp(
            transform.position,
            movePos,
            Time.deltaTime * 10);
    }
}
