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
    public GameObject createScreen;
    public Canvas roomCanvas;
    public Canvas menuCanvas;

    [Header("Main Screen")]
    public Button createRoomButton;
    public Button joinRoomButton;
    public GameObject playerAlert;
    public GameObject roomAlert;
    public TMP_InputField roomNameInput;
    public TMP_InputField playerNameInput;
    public Slider maxPlayersSlider;
    public Text maxPlayersValue;

    [Header("Lobby Screen")]
    public TextMeshProUGUI playerListText;
    public Button startGameButton;



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
        createScreen.SetActive(false);

        screen.SetActive(true);
    }

    public void CreateRoomScreen()
    {
        var alerName = playerNameInput.text;
        if (!string.IsNullOrEmpty(alerName))
        {
            SetScreen(createScreen);
            playerAlert.SetActive(false);
        }
        else
        {
            playerAlert.SetActive(true);
        }
    }

    public void OnCreateRoomButton()
    {
        var alerRoom = roomNameInput.text;

        if (!string.IsNullOrEmpty(alerRoom))
        {
            NetworkManager.instance.CreateRoom(roomNameInput.text, (byte)maxPlayersSlider.value);
            roomAlert.SetActive(false);
        }
        else
        {
            roomAlert.SetActive(true);
        } 
    }

    public void ListRoomScreen()
    {
        var alerName = playerNameInput.text;
        if (!string.IsNullOrEmpty(alerName))
        {
            roomCanvas.sortingOrder = 1;
            menuCanvas.sortingOrder = 0;
            playerAlert.SetActive(false);
        }
        else
        {
            playerAlert.SetActive(true);
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
        roomCanvas.sortingOrder = 0;
        menuCanvas.sortingOrder = 1;
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

    public void ChangeMaxPlayersSlider(float value)
    {
        maxPlayersValue.text = Mathf.RoundToInt(value).ToString();
    }

    public void OnLeaveLobbyButton()
    {
        PhotonNetwork.LeaveRoom();
        SetScreen(mainScreen);
    }

    public void OnLeaveRoomButton()
    {
        roomCanvas.sortingOrder = 0;
        menuCanvas.sortingOrder = 1;
    }

    public void OnLeavaRoomCreate()
    {
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
