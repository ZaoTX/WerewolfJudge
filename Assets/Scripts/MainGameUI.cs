using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //--------------------Canvas----------------------
    public GameObject LobbyPanel;
    public GameObject WerewolfPanel;
    public Button killButton;
    public GameObject WitchPanel;
    public GameObject SeerPanel;
    public GameObject HunterPanel;
    public GameObject VillagerPanel;
    public GameObject SelectPlayerPanel; 
    // This is only set on client to the ID of the local player
    public int localplayerID;
    public WWPlayer player;
    public GameLogic gameLogic;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void OnStartClient()
    {
        base.OnStartClient();
        //Update player seats
        if (LobbyPanel.active == true) { 
            //send to all to active player's seat

        }
    }
    public void setupSeats() {
        setSeat(localplayerID);
        Debug.Log("ID is: "+ localplayerID);
    }
     void setSeat(int seatID) { 
        switch (seatID) {
            case 1:
                avatar1.SetActive(true);
                break;
            case 2:
                avatar2.SetActive(true); 
                break;
            case 3:
                avatar3.SetActive(true);
                break;
            case 4:
                avatar4.SetActive(true);
                break;
            case 5:
                avatar5.SetActive(true);
                break;
            case 6:
                avatar6.SetActive(true);
                break;
            case 7:
                avatar7.SetActive(true);
                break;
            case 8:
                avatar8.SetActive(true);
                break;
            case 9:
                avatar9.SetActive(true);
                break;
            default:
                Debug.Log("ID should between 1 to 9");
                break;
        }
    }
    void ReceiveJoin() { 
        //When someone enters the game then set avatar active
    }
    public void OnClickStartGame() {
        //Start the game by shuffle the roles and show player the corresponding panel
        if (gameLogic.roles != null) { 
            //jump to their role panel
            LobbyPanel.SetActive(false);
            switch (gameLogic.roles[gameLogic.playerID - 1]) {
                case PlayerRole.WEREWOLF:
                    WerewolfPanel.SetActive(true);
                    break;
                case PlayerRole.VILLAGER:
                    VillagerPanel.SetActive(true);
                    break ;
                case PlayerRole.SEER:
                    SeerPanel.SetActive(true);
                    break;
                case PlayerRole.Witch:
                    WitchPanel.SetActive(true);
                    break;
                case PlayerRole.Hunter:
                    HunterPanel.SetActive(true);    
                    break;
            }
        }
    }
    public void OnClickKillPlayer() {
        //The ww clicked on kill button
        //show Panel to let him select player
        SelectPlayerPanel.SetActive(true);
        WerewolfPanel.SetActive(true);
        UnToggleKillButtons();
    }
    [ClientRpc]
    void UnToggleKillButtons()
    {
        if (gameLogic.playerRole == PlayerRole.WEREWOLF) {
            killButton.interactable = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
