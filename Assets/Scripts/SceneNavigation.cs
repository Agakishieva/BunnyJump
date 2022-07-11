using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation
{
    private static readonly Stack<string> scenes = new Stack<string>();
    public const string mainSceneName = "MainScene";
    public const string playSceneName = "PlayScene";

    static SceneNavigation()
    {
        //
    }

    public static void AddSceneToStack()
    {
        string currentName = SceneManager.GetActiveScene().name;
        if (currentName != mainSceneName)
        {
            scenes.Push(currentName);
        }
    }

    public static void NavigatePlay()
    {
        AddSceneToStack();
        SceneManager.LoadScene(playSceneName);
    }

    public static void NavigateMain()
    {
        AddSceneToStack();
        SceneManager.LoadScene(mainSceneName);
    }
}
