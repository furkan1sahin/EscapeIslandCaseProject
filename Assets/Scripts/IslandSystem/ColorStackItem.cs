using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorStackItem : MonoBehaviour
{
    //public Colors myColor;
    public StackItemData itemData;
    Renderer myRenderer;

    Island oldIsland, currentIsland;

    StickmanController[] stickmans;
    int stickmanCount = 4;
    float separation = 1.0f;
    [SerializeField] GameObject stickmanPrefab;
    Vector3[] stickmanPositions;

    [SerializeField] GameObject pathwayPrefab;
    GameObject pathway;

    int migrateCounter = 0;

    private void Awake()
    {
        currentIsland = GetComponentInParent<Island>();

        stickmanPositions = new Vector3[stickmanCount];
        stickmans = new StickmanController[stickmanCount];
    }

    public void MoveToNewIsland(Island _newIsland, bool fastMove = false)
    {
        oldIsland = currentIsland;
        currentIsland = _newIsland;
        
        transform.parent = currentIsland.transform;
        if (fastMove)
        {
            transform.position = currentIsland.GetNextPosition();
            transform.rotation = currentIsland.transform.rotation;
            migrateCounter = 4;
            CompleteMigration();
        }

        UnparentStickmans();
        transform.position = currentIsland.GetNextPosition();
        transform.rotation = currentIsland.transform.rotation;
        CalculateStickmanPositions();
        List<Vector3> pathPoints = CreatePathPoints();

        pathway = Instantiate(pathwayPrefab);
        pathway.GetComponent<Pathway>().CreatePath(pathPoints.ToArray());

        StartCoroutine(SendStickmans(pathPoints));

        migrateCounter = 0;
    }

    IEnumerator SendStickmans(List<Vector3> pathPoints)
    {
        pathPoints.Add(stickmanPositions[0]);
        for (int i = 0; i < stickmans.Length; i++)
        {
            pathPoints[pathPoints.Count - 1] = stickmanPositions[i];
            stickmans[i].MoveToDestination(pathPoints.ToArray());
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void CompleteMigration()
    {
        migrateCounter++;
        if (migrateCounter >= 4)
        {
            oldIsland.UnHighlight();
            currentIsland.UnHighlight();
            currentIsland.CheckCompleted();
            if(pathway!=null) Destroy(pathway);
        }
    }

    public void InitializeItem(StackItemData data)
    {
        itemData = data;

        CalculateStickmanPositions();
        for (int i = 0; i < stickmanCount; i++)
        {
            GameObject newStickman = Instantiate(stickmanPrefab, transform, false);
            newStickman.transform.position = stickmanPositions[i];
            stickmans[i] = newStickman.GetComponent<StickmanController>();
            stickmans[i].InitializeSticman(this);
        }
    }

    void CalculateStickmanPositions()
    {
        float length = (float)(stickmanCount-1) * separation;
        for (int i = 0; i < stickmanCount; i++)
        {
            stickmanPositions[i] = transform.TransformPoint(new Vector3((-length / 2) + (i * separation), 0, 0));
        }
    }

    List<Vector3> CreatePathPoints()
    {
        List<Vector3> pathPoints = new List<Vector3>();
        pathPoints.Add(oldIsland.PathConnect.position);
        pathPoints.Add(oldIsland.PathHandle.position);
        pathPoints.Add(currentIsland.PathHandle.position);
        pathPoints.Add(currentIsland.PathConnect.position);

        return pathPoints;
    }

    void UnparentStickmans()
    {
        foreach (var item in stickmans) 
        { 
        item.transform.parent = null;
        }
    }
}
