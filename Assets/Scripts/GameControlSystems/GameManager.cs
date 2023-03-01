using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int CurrentLevel = 1;
    [SerializeField] ScriptableInt currentLevelData;
    [SerializeField] ScriptableEvent GameStartEvent;
    bool isGameStarted = false;
    bool isGameCompleted = false;
    [SerializeField] ScriptableEvent loadLevelEvent;

    LevelLoader levelLoader;

    private void Awake()
    {
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
    }

    void Start()
    {
        levelLoader = GetComponent<LevelLoader>();
        levelLoader.LoadLevel(CurrentLevel);
        loadLevelEvent.Invoke();
        currentLevelData.UpdateValue(CurrentLevel);
    }


    void Update()
    {
        if (!isGameStarted && Input.GetMouseButtonDown(0))
        {
            GameStartEvent.Invoke();
            isGameStarted = true;  
        }

        //if(isGameCompleted && Input.GetMouseButtonDown(0))
        //{
        //    levelLoader.LoadLevel(CurrentLevel);
        //    loadLevelEvent.Invoke();
        //    isGameCompleted = false;
        //    isGameStarted = false;
        //}
    }

    public void GameCompleted()
    {
        Debug.Log("LevelCompleted");
        isGameCompleted = true;
        CurrentLevel++;
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
    }

    public void GameFailed()
    {
        isGameCompleted = true;
    }

    public void LoadNextLevel()
    {
        loadLevelEvent.Invoke();
        isGameCompleted = false;
        isGameStarted = false;
        levelLoader.LoadLevel(CurrentLevel);
        currentLevelData.UpdateValue(CurrentLevel);
    }
}
