using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class IslandManager : MonoBehaviour
{
    Camera cam;
    Island highLightedIsland;

    [SerializeField] int colorsToComplete;
    int completedIslands = 0;

    [SerializeField] UnityEvent LevelCompleteEvent;
    [SerializeField] UnityEvent highlightEvent;
    UndoController undoController;

    void Start()
    {
        cam = Camera.main;
        undoController = GetComponent<UndoController>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }
    }

    void CheckClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 999f))
        {
            Island island = hit.transform.GetComponent<Island>();

            if(highLightedIsland == null && island != null)
            {
                if (island.stack.Count == 0) return; 
                highLightedIsland = island;
                highLightedIsland.Highlight();
                highlightEvent.Invoke();
                return;
            }

            if (island == null || island == highLightedIsland)
            {
                UnHighlight();
                return;
            }

            if (island.CheckAvailable(highLightedIsland.GetColor()))
            {
                island.Highlight();
                highlightEvent.Invoke();
                MigrateItem(island);
            } 
            else UnHighlight();
        }
    }

    void MigrateItem(Island island)
    {
        ColorStackItem itemToMove = highLightedIsland.stack.Pop();
        island.stack.Push(itemToMove);
        itemToMove.MoveToNewIsland(island);
        //UnHighlight();
        highLightedIsland = null;
        undoController.AddMove(highLightedIsland, island);
    }

    void UnHighlight()
    {
        highLightedIsland.UnHighlight();
        highLightedIsland = null;
    }

    public void IslandCompleted()
    {
        completedIslands++;
        if(completedIslands > colorsToComplete)
        {
            LevelCompleteEvent.Invoke();
        }
    }
}
