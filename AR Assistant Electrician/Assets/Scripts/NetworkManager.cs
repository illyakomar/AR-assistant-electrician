using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public static NetworkManager instance;

    public RoomItemUI _roomItemUIPrefab;
    public Transform _roomListParent;

    private List<RoomItemUI> _roomList = new List<RoomItemUI>();

    private void Awake()
    {
        if (instance != null && instance != this)
            gameObject.SetActive(false);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("JoinedLobby");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
        Debug.Log("ROOM LIST: " + roomList);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom(string roomName, byte option)
    {
        RoomOptions options = new RoomOptions() { MaxPlayers = option };
        PhotonNetwork.CreateRoom(roomName, options);
        Debug.Log("MaxPlayers: " + options.MaxPlayers);
    }

    public void JoinRoom(string roomName)
    {
        if (PhotonNetwork.PlayerList.Length <= 2)
        {
            PhotonNetwork.JoinRoom(roomName);
        }
    }

    private void UpdateRoomList(List<RoomInfo> roomList)
    {
        Debug.Log("UPDATE ROOM LIST: " + roomList);
        for (int i = 0; i < _roomList.Count; i++)
        {
            Destroy(_roomList[i].gameObject);
        }

        _roomList.Clear();

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].PlayerCount == 0) { continue; }

            RoomItemUI newRoomItem = Instantiate(_roomItemUIPrefab);
            newRoomItem.NetworkManager = this;
            newRoomItem.SetName(roomList[i].Name);
            newRoomItem.SetNumberPlayer($"{roomList[i].PlayerCount}/{roomList[i].MaxPlayers}");
            newRoomItem.transform.SetParent(_roomListParent);

            _roomList.Add(newRoomItem);
        }
    }

    [PunRPC]
    public void ChangeScene (string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }


}
