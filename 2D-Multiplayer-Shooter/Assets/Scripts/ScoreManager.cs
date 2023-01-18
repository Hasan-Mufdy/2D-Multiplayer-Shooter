using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static int score = 0;
    public PhotonView scoreView;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreView = GetComponent<PhotonView>();
    }
    public void increaseScore(){

    
    if(!scoreView.IsMine){
        score = score + 1;
        scoreText.text = score.ToString();
        }
    }  
    

    [PunRPC]        // sync the score between the players
    void Update()
    {
        scoreText.text = "score: " + score;
    }
}
