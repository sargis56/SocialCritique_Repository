using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    
    public const int maxHealth = 100;
    public GameObject spawnPoint;
    public bool destroyOnDeath;

    //[SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
    public RectTransform healthBar;

    //private NetworkStartPosition[] spawnPoints;

    public GameObject Player;
    public Transform location;
    
    private bool toggle;
    void Start ()
    {
        Player = GameObject.FindWithTag("PlayerC");
        //if (isLocalPlayer)
        //{
        //spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        //}
        toggle = true;
    }

    public void TakeDamage(int amount)
    {
        //if (!isServer)
        //{
        //    return;
        //}

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Instantiate(Player, location.position, Quaternion.identity);
            Player = GameObject.FindWithTag("PlayerC");
            //if (destroyOnDeath)
            //{
            Destroy(this.gameObject);
            toggle = false;

            //}
            //else { 

            //    currentHealth = maxHealth;

            //    Player.transform.position = spawnPoint.transform.position;
            //    //RpcRespawn();
            //}
        }

    }

    //[ClientRpc]
    //void RpcRespawn()
    //{
    //    if (isLocalPlayer)
    //    {

    //        // Set the spawn point to origin as a default value
    //        Vector3 spawnPoint = Vector3.zero;

    //        // If there is a spawn point array and the array is not empty, pick one at random
    //        if (spawnPoints != null && spawnPoints.Length > 0)
    //        {
    //            spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    //        }

    //        // Set the player’s position to the chosen spawn point
    //        transform.position = spawnPoint;
    //    }
    //}

    void OnChangeHealth (int currentHealth)
    {
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 50, 100, 30), "Reset"))
        {

            Player.transform.position = location.position;
        }

        if (GUI.Button(new Rect(150, 10, 100, 30), "Spawn"))
        {
            if (!toggle)
            {
                currentHealth = maxHealth;
                toggle = true;

            }
        }
    }

}

