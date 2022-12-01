using UniRx;
using UnityEngine;

public class ElementsGenerateManager : MonoBehaviour
{
    [SerializeField] private WorldController _worldController;
    
    private ElementsGenerate[] _elementsGenerate;

    private void Awake()
    {
        var count = transform.childCount;
        _elementsGenerate = new ElementsGenerate[count];   
        for (int i = 0; i < count; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out ElementsGenerate elementsGenerate))
            {
                _elementsGenerate[i] = elementsGenerate;
            }
        }

        _worldController?.ChageElementsGeneratePositinStreem.Subscribe(x => ChangedGeneratePart(x)).AddTo(this);
    }

    private void ChangedGeneratePart(ElementsGenerate element)
    {
        element.Generate();
    }
}
