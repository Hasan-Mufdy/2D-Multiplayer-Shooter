using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Weapon : MonoBehaviour
{
    public PhotonView bulletView;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    void Start(){
        bulletView = GetComponent<PhotonView>();
    }
    void Update()
    {
        if(Input.GetKeyDown("x") && bulletView.IsMine){
            shoot();
        }
    }
    public void shoot(){
        PhotonNetwork.Instantiate(bulletPrefab.name,shootingPoint.position,shootingPoint.rotation);
    }
}
