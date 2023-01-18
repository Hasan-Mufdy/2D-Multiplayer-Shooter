using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Text playerNameTest;
    public Transform playerNameTestPosition;
    public Text playerName;

    public Text playerNameTextScene;
    public GameObject playerCamera;
//////
    public Transform playerPosition;
    public SpriteRenderer sr;
    public SpriteRenderer shootingPointsr; 
    public float movementX;
//////
    public float moveSpeed = 10f;
    public float jumpSpeed = 11f;
//////
   
//////
    public Rigidbody2D body;
    public Collider2D coll;
//////
    public static bool isFacingRight = true;    
    public bool isOnGround = true;        //to prevent him from jumping from air
//////
    public PhotonView view;

    void Start()
    {
        PhotonNetwork.SendRate = 90;
        PhotonNetwork.SerializationRate = 30;
        view = GetComponent<PhotonView>(); 
        sr = GetComponent<SpriteRenderer>();
    }
    void Awake(){               // this method is for names only.
        if(view.IsMine){
            playerNameTextScene.text = PhotonNetwork.NickName;
        }
        else{
            playerNameTextScene.text = view.Owner.NickName;
        }        
    }

    void Update()
    {
        if(view.IsMine){   
        playerMovements();
        playerJump(); 
        }
    }

    public void playerJump(){
        if(Input.GetButtonDown("Jump") && isOnGround ){
            isOnGround = false;
            body.AddForce(new Vector2(0f, jumpSpeed) , ForceMode2D.Impulse);
        }
    }



    public void playerMovements(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position = transform.position + new Vector3(movementX, 0f, 0f) * moveSpeed * Time.deltaTime;
        // flip
        if(Input.GetKey(KeyCode.LeftArrow) && isFacingRight){    // old condition movementX<0
            view.RPC("flipRight",RpcTarget.All);
        }
        else if(Input.GetKey(KeyCode.RightArrow)  && !isFacingRight){ // old condition movementX>0
            view.RPC("flipLeft",RpcTarget.All);
        }

    }

///////////////////////////
      [PunRPC]
    public void flipRight(){
        isFacingRight = false;
        sr.flipX = true;
    }
    [PunRPC]
    void flipLeft(){
        isFacingRight = true;
        sr.flipX = false;
    }

/////////////////////////////////
    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround = true;

        }

    }

     public void ButtonJump(){
        if(isOnGround){
        isOnGround = false;
        body.AddForce(new Vector2(0f, jumpSpeed) , ForceMode2D.Impulse);
        }
    }
}
