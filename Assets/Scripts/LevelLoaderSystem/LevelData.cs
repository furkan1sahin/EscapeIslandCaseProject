using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    public const string LevelPath = "Assets/Scenes/Levels/";
    [SerializeField] string levelName;
    
    

    public int SceneIndex
    {
        get
        {
            return SceneUtility.GetBuildIndexByScenePath(LevelPath + levelName + ".unity");
        }
    }
}
