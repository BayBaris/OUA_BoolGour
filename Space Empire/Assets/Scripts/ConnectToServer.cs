using UnityEngine;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public GameObject loading;
    public GameObject createOrJoin;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        loading.gameObject.SetActive(true);
        createOrJoin.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public override void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){
        loading.gameObject.SetActive(false);
        createOrJoin.gameObject.SetActive(true);
    }
}
