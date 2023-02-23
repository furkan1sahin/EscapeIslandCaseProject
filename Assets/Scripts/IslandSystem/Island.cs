using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public enum Colors
{
    Red,
    Green, 
    Blue
}

public class Island : MonoBehaviour
{
    bool Highlighted = false;
    public int StackCapacity = 4;

    //island stack has squads
    //squad has own soldiers, they go to different islands
    //island has squad points
    //soldiers gets next islans.squadpoints and go to destination
    //soldiers take destination by hadle positions and target positions
    //sequence them and goes by
    //island getnextposition and position filled

    public Stack<ColorStackItem> stack = new Stack<ColorStackItem>();
    public Transform[] itemPositions;

    [SerializeField] GameObject stackItemPrefab;
    [SerializeField] StackItemData[] startItems;

    void Start()
    {
        LoadItems();
    }

    
    void Update()
    {
        
    }

    void LoadItems()
    {
        for (int i = 0; i < startItems.Length; i++)
        {
            GameObject newItem = Instantiate(stackItemPrefab, itemPositions[i]);
            ColorStackItem item = newItem.GetComponent<ColorStackItem>();
            item.InitializeItem(startItems[i]);
            stack.Push(item);
        }
    }

    public bool CheckAvailable(Colors color)
    {
        if(stack.Count >= StackCapacity) return false;
        if(stack.Count == 0) return true;
        return color == GetColor();
    }

    public void Clicked()
    {
        if(!Highlighted) { 
        Highlighted= true;
            Highlight();
        }
        else
        {
            Highlighted= false;
            UnHighlight();
        }
    }

    public void Highlight()
    {
        transform.DOMoveY(1, 0.4f);
        Highlighted = true;
    }

    public void UnHighlight()
    {
        transform.DOMoveY(0, 0.2f);
        Highlighted = false;
    }

    public Colors GetColor()
    {
        return stack.Peek().itemData.colorType;
    }

    public Vector3 GetNextPosition()
    {
        return itemPositions[stack.Count - 1].position;
    }
}
