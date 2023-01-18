using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    public static SpawnPlayer Instance;
    public GameObject respawnMenu;
    public bool runSpawnTimer = false;
    public GameObject playerPrefab;
    public GameObject canvas;
    public GameObject sceneCamera;

    // x and y values to generate a random position:
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));  //instantiate the player on a random location  
        PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);// Quaternion.identity ---> no rotation
        playerPrefab.SetActive(true);  // player prefab ---> in the resources folder
        Instance = this;
    }
}
