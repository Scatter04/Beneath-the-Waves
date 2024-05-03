using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject player;
    [Space]
    public Transform spawnPoint;
    void Start()
    {
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings();
        
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log("Connected To Server");

        PhotonNetwork.JoinLobby();
    }


    
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("test", null, null);
        Debug.Log("Joined Lobby, In the Lobby Now.");

    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("We're Connected and in a room now");
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }
}
