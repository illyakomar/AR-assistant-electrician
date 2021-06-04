using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class RoomItemUI : MonoBehaviourPunCallbacks
{
    public NetworkManager NetworkManager;
    [SerializeField] private TextMeshProUGUI _roomName;
    [SerializeField] private Text _maxPlayer;


    public void SetName(string roomName)
    {
        _roomName.text = roomName;
    }

    public void SetNumberPlayer(string maxPlayer)
    {
        _maxPlayer.text = maxPlayer;
    }

    public void OnJoinRoomButton()
    {
        NetworkManager.instance.JoinRoom(_roomName.text);
    }
}
