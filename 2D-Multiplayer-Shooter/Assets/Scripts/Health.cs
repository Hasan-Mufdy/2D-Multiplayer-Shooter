using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class Health : MonoBehaviourPunCallbacks
{
    public Vector3 position;
    public Image fillImage;
    public float healthAmount;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public SpriteRenderer sr;
    // public bool disableMoves;
                            
    public void checkHealth(){

        fillImage.fillAmount = healthAmount/100f;
        if(photonView.IsMine && healthAmount<=0){

            this.GetComponent<PhotonView>().RPC("respawn",RpcTarget.All);
        }
        if(!photonView.IsMine && healthAmount<=0){
        ScoreManager.score = ScoreManager.score + 1;   //** increase the score, ScoreManager class ... score --> static variable 
        }
    }

    [PunRPC]
    public void respawn(){
        fillImage.fillAmount = 1f;
        healthAmount = 100f; 
        changePosition();
    }
    public void changePosition(){  
        gameObject.transform.position = new Vector3(0,0,0);
    }

    [PunRPC]
    public void reduceHealth(float amount){
        modifyHealth(amount);
    }
    public void modifyHealth(float amount){
        if(photonView.IsMine){
            healthAmount-=amount;
            fillImage.fillAmount -= amount;
        }   
        else{
            healthAmount-=amount;
            fillImage.fillAmount -= amount;
        }  
        checkHealth(); /////***** 
    }
      public void OnCollisionEnter2D(Collision2D collision){  // if the player jumped out of the game
        if(collision.gameObject.CompareTag("Reset")){
            this.GetComponent<PhotonView>().RPC("respawn",RpcTarget.All);
            if(ScoreManager.score >= 1){
            ScoreManager.score = ScoreManager.score - 1;  // after the players killed their self, their score will decrease.
            }
        }
    }
}
  

