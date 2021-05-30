using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class LabMultiplayerManager : MonoBehaviourPunCallbacks
{

    [Header("Screens")]
    public GameObject mainScreen;
    public GameObject lobbyScreen;
    public GameObject loadingScreen;


    [Header("Main Screen")]
    public Button createRoomButton;
    public Button joinRoomButton;
    public GameObject playerAndRoomNameAlert;
    public TMP_InputField roomNameInput;
    public TMP_InputField playerNameInput;

    [Header("Lobby Screen")]
    public TextMeshProUGUI playerListText;
    public Button startGameButton;
    public TextMeshProUGUI roomNameText;


    private void Start()
    {
        createRoomButton.interactable = false;
        joinRoomButton.interactable = false;
    }

    public override void OnConnectedToMaster()
    {
        createRoomButton.interactable = true;
        joinRoomButton.interactable = true;
    }

    private void SetScreen(GameObject screen)
    {
        mainScreen.SetActive(false);
        lobbyScreen.SetActive(false);

        screen.SetActive(true);
    }

    public void OnCreateRoomButton()
    {
        var alerRoom = roomNameInput.text;
        var alerName = playerNameInput.text;

        if (!string.IsNullOrEmpty(alerRoom) && !string.IsNullOrEmpty(alerName))
        {
            NetworkManager.instance.CreateRoom(roomNameInput.text);
            roomNameText.text = roomNameInput.text;
            playerAndRoomNameAlert.SetActive(false);
        }
        else
        {
            playerAndRoomNameAlert.SetActive(true);
        } 
    }

    public void OnJoinRoomButton()
    {
        var alerRoom = roomNameInput.text;
        var alerName = playerNameInput.text;

        if (!string.IsNullOrEmpty(alerRoom) && !string.IsNullOrEmpty(alerName))
        {
            NetworkManager.instance.JoinRoom(roomNameInput.text);
            roomNameText.text = roomNameInput.text;
            playerAndRoomNameAlert.SetActive(false);
        }
        else
        {
            playerAndRoomNameAlert.SetActive(true);
        }
    }

    public void OnPlayerNameUpdate(TMP_InputField playerNameInput)
    {
        playerNameInput.characterLimit = 16;
        PhotonNetwork.NickName = playerNameInput.text;
    }

    public void OnRoomNameUpdate(TMP_InputField roomNameInput)
    {
        roomNameInput.characterLimit = 16;
    }

    public override void OnJoinedRoom()
    {
        SetScreen(lobbyScreen);
        photonView.RPC("UpdateLobbyUI", RpcTarget.All);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdateLobbyUI();
    }

    [PunRPC]
    public void UpdateLobbyUI()
    {
        playerListText.text = "";

        foreach(Player player in PhotonNetwork.PlayerList)
        {
            if (player.IsMasterClient)
                playerListText.text += player.NickName + " (Host) \n";
            else
                playerListText.text += player.NickName + "\n";
        }

        if (PhotonNetwork.IsMasterClient)
            startGameButton.interactable = true;
        else startGameButton.interactable = false;
    }


    public void OnLeaveLobbyButton()
    {
        PhotonNetwork.LeaveRoom();
        SetScreen(mainScreen);
    }


    public void OnStartGameButton()
    {
        loadingScreen.SetActive(true);
        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "GameLevelLab");
    }

    public void GoBackToMainMenu()
    {
        Destroy(NetworkManager.instance.gameObject);
        PhotonNetwork.Disconnect();
        NetworkManager.instance.ChangeScene("Menu");
    }
}
