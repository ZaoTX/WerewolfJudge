using Mirror;
using Mirror.Examples.Chat;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[AddComponentMenu("")]
public class WWNetworkManager : NetworkManager
{
    public static new WWNetworkManager singleton { get; private set; }
    public WWPlayer player;
    /// <summary>
    /// Runs on both Server and Client
    /// Networking is NOT initialized when this fires
    /// </summary>
    public override void Awake()
    {
        base.Awake();
        singleton = this;
    }
    
 
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        /*// remove player name from the HashSet
        if (conn.authenticationData != null)
            ChatAuthenticator.playerNames.Remove((string)conn.authenticationData);

        // remove connection from Dictionary of conn > names
        ChatUI.connNames.Remove(conn);*/

        base.OnServerDisconnect(conn);
    }

    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();
        /*LoginUI.instance.gameObject.SetActive(true);
        LoginUI.instance.usernameInput.text = "";
        LoginUI.instance.usernameInput.ActivateInputField();*/
    }

}
