using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Menu : NetworkBehaviour
{
    [SerializeField] private string newLevel;
    public GameObject Player;
    public Transform Lobby;

    // Use this for initialization
    //void Awake()
    //{
    //    Instantiate(Player, Lobby.position, Quaternion.identity);
    //}

    //private void Start()
    //{
    //    DontDestroyOnLoad(Player);
    //}
    IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newLevel, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByName(newLevel));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(LoadYourAsyncScene());
        }
    }
    //        if (other.gameObject.tag == "Player")
    //    {
    //        Scene sceneToLoad = SceneManager.GetSceneByName(newLevel);
    //SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Additive);
    //        SceneManager.MoveGameObjectToScene(other.gameObject, sceneToLoad);
    //        Debug.Log("Level Changing");

    //    }
}
