using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Unity.VisualScripting;
using UnityEngine.Events;

public class Island : MonoBehaviour
{
    bool Highlighted = false;
    public bool Completed = false;
    public int StackCapacity = 4;

    Stack<ColorStackItem> stack = new Stack<ColorStackItem>();
    public Transform[] itemPositions;

    [SerializeField] GameObject stackItemPrefab;
    [SerializeField] StackItemData[] startItems;
    
    public Transform PathConnect, PathHandle;

    [SerializeField] GameObject completedFlag;
    [SerializeField] Renderer flagRenderer;
    [SerializeField] ParticleSystem completedParticles;

    float unHighlightTime;
    [SerializeField] UnityEvent IslandCompletedEvent;

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

    public bool CheckHighlightable()
    {
        return stack.Count > 0 && !Completed;
    }

    public bool CheckAvailable(Colors color, int count)
    {
        if(count>(StackCapacity-stack.Count)) return false;
        if(stack.Count >= StackCapacity) return false;
        if(stack.Count == 0) return true;
        return color == GetColor();
    }

    public void CheckCompleted()
    {
        if(Completed) return;
        if (stack.Count < StackCapacity) return;
        ColorStackItem[] stackItems = stack.ToArray();
        Colors currentStackColor = stackItems[0].itemData.colorType;

        for (int i = 0; i < stackItems.Length; i++)
        {
            if (stackItems[i].itemData.colorType != currentStackColor) return;
        }

        SetCompleted();
    }

    void SetCompleted()
    {
        Completed = true;
        IslandCompletedEvent.Invoke();
        if (completedFlag != null)
        {
            completedFlag.SetActive(true);
            completedFlag.transform.DOMoveY(0, 0.5f);
            flagRenderer.material = stack.Peek().itemData.material;
        }
        if (completedParticles != null) completedParticles.Play();
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

    public ColorStackItem PopNextItem()
    {
        if (stack.Count == 0) return null;
        return stack.Pop();
    }

    public ColorStackItem PeekNextItem() 
    {
        if(stack.Count == 0) return null;
        return stack.Peek();
    }

    public void PushNextItem(ColorStackItem item)
    {
        stack.Push(item);
    }

    public int GetRecursiveItemCount()
    {
        if(stack.Count == 0) return 0;
        Stack<ColorStackItem> tempStack = new Stack<ColorStackItem>();
        Colors topColor = stack.Peek().itemData.colorType;
        int count = 0;
        while(stack.Count>0 && stack.Peek().itemData.colorType == topColor)
        {
            tempStack.Push(stack.Pop());
            count++;
        }
        while(tempStack.Count > 0)
        {
            stack.Push(tempStack.Pop());
        }
        return count;
    }

    public int GetItemCount()
    {
        return stack.Count;
    }
}
