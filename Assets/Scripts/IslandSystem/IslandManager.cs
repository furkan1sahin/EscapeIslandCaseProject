using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                if (!island.CheckHighlightable()) return; 
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

            if (island.CheckAvailable(highLightedIsland.GetColor(), highLightedIsland.GetRecursiveItemCount()))
            {
                island.Highlight();
                highlightEvent.Invoke();
                //MigrateItem(island);
                StartCoroutine(MigrateItems(island));
            } 
            else UnHighlight();
        }
    }

    void MigrateItem(Island island)
    {
        ColorStackItem itemToMove = highLightedIsland.PopNextItem();
        island.PushNextItem(itemToMove);

        itemToMove.MoveToNewIsland(island);
        //UnHighlight();
        highLightedIsland = null;
        undoController.AddMove(highLightedIsland, island);
    }

    IEnumerator MigrateItems(Island island)
    {
        Island fromIsland = highLightedIsland;
        highLightedIsland = null;

        Colors colorToMove = fromIsland.PeekNextItem().itemData.colorType;

        while(fromIsland.GetItemCount()>0 && fromIsland.PeekNextItem().itemData.colorType == colorToMove)
        {
            ColorStackItem itemToMove = fromIsland.PopNextItem();
            island.PushNextItem(itemToMove);
            itemToMove.MoveToNewIsland(island);

            yield return new WaitForSeconds(itemToMove.GetItemMoveDelay());
        }
        fromIsland.UnHighlight();
        undoController.AddMove(fromIsland, island);
    }

    void UnHighlight()
    {
        if (highLightedIsland == null) return;
        highLightedIsland.UnHighlight();
        highLightedIsland = null;
    }

    public void IslandCompleted()
    {
        Debug.Log("Completed islands: " + completedIslands.ToString());
        completedIslands++;
        if(completedIslands >= colorsToComplete)
        {
            LevelCompleteEvent.Invoke();
        }
    }
}
