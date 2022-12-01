using System;
using UniRx;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;
    [SerializeField] private ElementsGenerate[] _worldParts;

    private Transform _currentActivePart;
    private Transform _currentDeActivePart;

    private bool activate = true;

    public IObservable<ElementsGenerate> ChageElementsGeneratePositinStreem => _elementsGeneratePositionChange;
    private Subject<ElementsGenerate> _elementsGeneratePositionChange = new();
    private void Update()
    {
        foreach (var VARIABLE in _worldParts)
        {
            if (VARIABLE.transform.position.y < -20)
            {
                VARIABLE.transform.localPosition += new Vector3(0, 10 * _worldParts.Length, 0);
                _elementsGeneratePositionChange.OnNext(VARIABLE);
            }
        }
        
        transform.Translate(0,-Time.deltaTime * _scrollSpeed,0);
    }
}
