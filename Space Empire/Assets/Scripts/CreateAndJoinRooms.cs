using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createRoomInput;
    public TMP_InputField joinRoomInput;

    public void CreateRoom(){
        PhotonNetwork.CreateRoom(createRoomInput.text.Trim());
    }
    public void JoinRoom(){
        PhotonNetwork.JoinRoom(joinRoomInput.text.Trim());
    }

    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("WarScene");
    }
}
