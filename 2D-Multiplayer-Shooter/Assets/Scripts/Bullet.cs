using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Bullet : MonoBehaviourPunCallbacks
{
    public float bulletSpeed =10f;    
    public float timeToLive;
    public float bulletDamage;
    public Rigidbody2D bulletBody;
    public int damage = 30;
    public int health;

    void Start()
    {
        if(PlayerController.isFacingRight == true){
            bulletBody.velocity = transform.right * bulletSpeed;
                transform.localScale = new Vector3(1,1,1);

        }
        else if(PlayerController.isFacingRight == false){
            bulletBody.velocity = transform.right * -1 * bulletSpeed;
                transform.localScale = new Vector3(-1,1,1);

        }
      
        Destroy(gameObject, 5);    //TO DESTROY THE BULLET AUTOMATICALLY AFTER 5 SECONDS
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
         if(!photonView.IsMine){
            Destroy(gameObject); // gameObject ---> Bullet
        }
       // damage:
        if(!photonView.IsMine){
            return;
        }
        PhotonView target = hitInfo.gameObject.GetComponent<PhotonView>();
        if(target != null && (!target.IsMine)){
            if(target.tag == "Player"){
                target.RPC("reduceHealth",RpcTarget.All,bulletDamage);
            }
        }
    }
}










