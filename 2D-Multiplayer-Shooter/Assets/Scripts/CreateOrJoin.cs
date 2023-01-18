using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class CreateOrJoin : MonoBehaviourPunCallbacks
{
    public InputField createIn;
    public InputField joinIn;
    public void CreateRoom(){
        PhotonNetwork.CreateRoom(createIn.text,new Photon.Realtime.RoomOptions(){MaxPlayers = 2});  // this will allow only 2 players to join a room
    }
    public void JoinRoom(){
        PhotonNetwork.JoinRoom(joinIn.text);
    }
    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("Game");
    }
}
