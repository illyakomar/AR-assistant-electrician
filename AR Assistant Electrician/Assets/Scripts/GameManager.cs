using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using TMPro;

public class GameManager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI playerListText;
    public GameObject rootPanel;
    [HideInInspector]
    public PlayerController[] players;  
    [HideInInspector]
    private int playersInGame;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        players = new PlayerController[PhotonNetwork.PlayerList.Length];
        photonView.RPC("ImInGame", RpcTarget.AllBuffered);
    }

  
    [PunRPC]
    void ImInGame()
    {
        playersInGame++;

        playerListText.text = "";

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player.IsMasterClient)
                playerListText.text += player.NickName + " (Host) \n";
            else
                playerListText.text += player.NickName + "\n";
        }

        if (PhotonNetwork.IsMasterClient)
            rootPanel.SetActive(true);
        else rootPanel.SetActive(false);
    }

    

    public void GoBackToMenu()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        NetworkManager.instance.ChangeScene("MenuMultiplayer");
    }
}
