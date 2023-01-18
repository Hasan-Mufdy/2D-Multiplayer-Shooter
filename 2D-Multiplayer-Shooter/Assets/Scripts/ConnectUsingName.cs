using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectUsingName : MonoBehaviourPunCallbacks
{
    public InputField nameInput;        // this is the entered name, will be stored by photon 
    public static string playerName;
    public Text buttonText;
    public void OnClickConnect(){
        if(nameInput.text.Length >= 1){
            PhotonNetwork.NickName = nameInput.text;         
            buttonText.text = "Connecting...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void OnConnectedToMaster(){
        SceneManager.LoadScene("Lobby");
    }
    
    public void connectAsAGuest(){
        SceneManager.LoadScene("Loading");
    }
    // Start is called before the first frame update
    void Start()
    {
        playerName = nameInput.text;  
    }
}
