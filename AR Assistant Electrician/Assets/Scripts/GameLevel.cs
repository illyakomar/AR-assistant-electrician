using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class GameLevel : MonoBehaviour
{
    public TextMeshProUGUI playerListText;

    [PunRPC]
    public void LobbyUI()
    {
        playerListText.text = "";

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player.IsMasterClient)
                playerListText.text += player.NickName + " (Host) \n";
            else
                playerListText.text += player.NickName + "\n";
        }

    }

}
