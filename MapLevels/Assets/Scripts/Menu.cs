using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Player;
    public Transform location;
    public string currentscene;

    // Use this for initialization
    void Start()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Change Scene"))
        {


            SceneManager.LoadScene("Scenes/MenuScene");
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(currentscene);
        }

    }
}
