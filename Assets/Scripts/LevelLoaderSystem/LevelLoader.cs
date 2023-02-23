using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] List<LevelData> LevelList = new List<LevelData>();
    [SerializeField] ScriptableEvent SceneLoadedEvent;

    int LastLoaded = -1;

    public void LoadLevel(int LevelIndex)
    {
        LevelIndex--;
        LevelIndex = LevelIndex % LevelList.Count;

        LoadScene(LevelIndex);
    }

    void LoadScene(int levelIndex)
    {
        if (LastLoaded >= 0) SceneManager.UnloadSceneAsync(LastLoaded);
        SceneManager.LoadSceneAsync(LevelList[levelIndex].SceneIndex, LoadSceneMode.Additive);
        LastLoaded = LevelList[levelIndex].SceneIndex;
        SceneLoadedEvent.Invoke();
    }
}
