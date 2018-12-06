using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Menu : NetworkBehaviour
{
    //private AssetBundle myLoadedAssetBundle;
    //private string[] scenePaths;

    //// Use this for initialization
    //void Start()
    //{
    //    myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
    //    scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    //}

    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(10, 10, 100, 30), "Change Scene"))
    //    {
    //        Debug.Log("Scene2 loading: " + scenePaths[2]);
    //        SceneManager.LoadScene(scenePaths[2], LoadSceneMode.Single);
    //    }
    //}
}
