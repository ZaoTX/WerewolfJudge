using Mirror;
using Mirror.Examples.Chat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWPlayer : NetworkBehaviour
{
    public PlayerRole role;
    public GameObject PlayerUI;
    [SyncVar]
    public int playerID;
    public GameLogic gameLogic;
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (gameLogic == null) {
            gameLogic = GameObject.Find("[GameLogic]").GetComponent<GameLogic>();
        }
        Debug.Log("Function called OnStartLocalPlayer" +  gameLogic.playerID);
    }
    [Server]
    public override void OnStartServer()
    {

        base.OnStartServer();
        if (gameLogic == null)
        {
            gameLogic = GameObject.Find("[GameLogic]").GetComponent<GameLogic>();
        }
        Debug.Log("Function called OnStartLocalPlayer" + gameLogic.playerID);
        Debug.Log("Function called on start Server" + playerID); 
        //playerID = (int)connectionToClient.authenticationData;
    }
    
}
