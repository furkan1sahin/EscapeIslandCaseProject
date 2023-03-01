using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveData
{
    public Island from;
    public Island to;
}

public class UndoController : MonoBehaviour
{
    int maxUndo = 5;
    int undoLeft;
    List<MoveData> moves = new List<MoveData>();

    void Start()
    {
        undoLeft = maxUndo;
    }

    public void AddMove(Island _from, Island _to)
    {
        moves.Add(new MoveData { from = _from, to = _to });

        if(moves.Count > maxUndo ) 
        { 
            moves.RemoveAt(0);
        }
    }

    public void Undo()
    {
        if(moves!= null && undoLeft>0) 
        {
            int i = moves.Count -1;
            ColorStackItem itemToMove = moves[i].to.PopNextItem();
            moves[i].from.PushNextItem(itemToMove);
            itemToMove.MoveToNewIsland(moves[i].from);
            moves.RemoveAt(i);
        }
    }
}
