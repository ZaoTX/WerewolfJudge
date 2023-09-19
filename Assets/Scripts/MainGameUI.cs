using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public struct PlayerMoveMsg : NetworkMessage 
    {
        
    }
}

public class MainGameUI : NetworkBehaviour
{
    public GameObject avatar1;
    public GameObject avatar2;
    public GameObject avatar3;
    public GameObject avatar4;
    public GameObject avatar5;
    public GameObject avatar6;
    public GameObject avatar7;
    public GameObject avatar8;
    public GameObject avatar9;
    // This is only set on client to the name of the local player
    internal static string localPlayerName;
    internal static readonly Dictionary<NetworkConnectionToClient, string> connNames = new Dictionary<NetworkConnectionToClient, string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void OnStartServer()
    {
        connNames.Clear();
    }

    public override void OnStartClient()
    {
        avatar1.SetActive(false);
        avatar2.SetActive(false);
        avatar3.SetActive(false);
        avatar4.SetActive(false);
        avatar5.SetActive(false);
        avatar6.SetActive(false);
        avatar7.SetActive(false);
        avatar8.SetActive(false);
        avatar9.SetActive(false);
    }
    //randomly distribute all roles
    public void OnClickStartGame() {
        //NetworkServer.SendToAll(new );
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
