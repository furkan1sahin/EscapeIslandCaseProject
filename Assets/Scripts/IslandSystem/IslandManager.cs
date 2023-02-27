using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IslandManager : MonoBehaviour
{
    Camera cam;
    Island highLightedIsland;

    void Start()
    {
        cam = Camera.main;    
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
    }

    void UnHighlight()
    {
        highLightedIsland.UnHighlight();
        highLightedIsland = null;
    }
}
