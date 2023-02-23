using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorStackItem : MonoBehaviour
{
    //public Colors myColor;
    public StackItemData itemData;
    Renderer myRenderer;

    private void Awake()
    {
        
    }

    public void MoveToNewIsland(Island newIsland)
    {
        transform.DOMove(newIsland.GetNextPosition(), 2f);
    }

    public void InitializeItem(StackItemData data)
    {
        itemData = data;
        if(myRenderer== null) myRenderer = GetComponentInChildren<Renderer>();
        myRenderer.material = itemData.material;
    }
}
