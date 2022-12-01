using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElementsGenerate : MonoBehaviour
{
   public float offsetY;
   [SerializeField] private Transform _rightBlock;
   [SerializeField] private Transform _leftBlock;
   [SerializeField] private Transform _content;
   private List<Transform> elements;
   private Vector2 _worldSize;
   private int zoneIndex = 5;

   private void Awake()
   {
      elements = new List<Transform>();
   }

   public void Generate()
   {
      if (elements.Count > 0)
      {
         for (int i = 0; i < elements.Count; i++)
         {
            Destroy(elements[i].gameObject);
            elements.Remove(elements[i]);
         }
      }
      
      int start = 4;
      int end = 10;
      
      var randStart = Random.Range(0, start);
      var randEnd = Random.Range(randStart, end);
      
      for (int i = 0; i < 7; i++)
      {
         if(!(i > randStart && i < randEnd))
            Generate(10 - (0.5f + i)  / offsetY,GetRandom());
      }
   }

   private int lastIndex;
   private float GetRandom()
   {
      if (lastIndex + 1 > 7)
      {
         lastIndex = 0;
      }
      return lastIndex++;
   }

   private void Generate(float x, float y)
   {
      var item = Instantiate(_rightBlock, _content);
      item.localPosition = new Vector3(x, y) / 10;
      elements.Add(item);
   }
}
