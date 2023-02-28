using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Island : MonoBehaviour
{
    bool Highlighted = false;
    public bool Completed = false;
    public int StackCapacity = 4;

    public Stack<ColorStackItem> stack = new Stack<ColorStackItem>();
    public Transform[] itemPositions;

    [SerializeField] GameObject stackItemPrefab;
    [SerializeField] StackItemData[] startItems;
    
    public Transform PathConnect, PathHandle;

    [SerializeField] GameObject completedFlag;
    [SerializeField] Renderer flagRenderer;
    [SerializeField] ParticleSystem completedParticles;

    float unHighlightTime;

    void Start()
    {
        LoadItems();
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

    public void CheckCompleted()
    {
        if (stack.Count < StackCapacity) return;
        ColorStackItem[] stackItems = stack.ToArray();
        Colors currentStackColor = stackItems[0].itemData.colorType;

        for (int i = 0; i < stackItems.Length; i++)
        {
            if (stackItems[0].itemData.colorType != currentStackColor) return;
        }

        SetCompleted();
    }

    void SetCompleted()
    {
        Completed = true;
        if (completedFlag != null)
        {
            completedFlag.SetActive(true);
            completedFlag.transform.DOMoveY(0, 0.5f);
            flagRenderer.material = stack.Peek().itemData.material;
        }
        if (completedParticles != null) completedParticles.Play();
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
