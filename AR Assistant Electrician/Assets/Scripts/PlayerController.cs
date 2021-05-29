using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPunCallbacks
{
    [HideInInspector]
    public int playerID;

    public Player photonPlayer;

    [PunRPC]
    public void Initialize(Player player)
    {
        photonPlayer = player;
        playerID = player.ActorNumber;

        GameManager.instance.players[playerID - 1] = this;

    }
}
