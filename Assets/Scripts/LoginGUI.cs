using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginGUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] internal InputField userIDinput;
    [SerializeField] internal Button hostButton;
    [SerializeField] internal Button clientButton;
    [SerializeField] internal Text errorText;
    //[SerializeField] internal GameObject MainGameLobby;
    
    public static LoginUI instance;
    public GameLogic gameLogic;
    public MainGameUI mainGame;
    // Called by UI element UsernameInput.OnValueChanged
    public void ToggleButtons(string username)
    {
        hostButton.interactable = !string.IsNullOrWhiteSpace(username);
        clientButton.interactable = !string.IsNullOrWhiteSpace(username);
    }
    //Called by UI element host and client buttion
    public void AssignPlayerID() {
        Debug.Log("Function called");
        mainGame.localplayerID = getPlayerID();
        gameLogic.playerID = getPlayerID();
    }
    public int getPlayerID() {
        return int.Parse(userIDinput.text);
    }
} 
