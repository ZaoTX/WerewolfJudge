
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using static GameLogic;


public class MainGameUI : MonoBehaviour
{
    public List<GameObject> avatarList;
    private List<GameObject> enabledAvatars = new List<GameObject>();
    //--------------------Select Panel----------------
    public List<Outline> SeatOutlineList;
    //--------------------Canvas----------------------
    public GameObject LobbyPanel;
    //-------------------Werewolf---------------------
    public GameObject WerewolfPanel;
    public Button killButton;
    public TMP_Text wwInfo;
    //-------------------Witch------------------------
    public GameObject WitchPanel;
    public TMP_Text witchInfo;
    public Button saveButton;
    public Button poisonButton;
    public Button witch_skipButton;
    //------------------Seer--------------------------
    public GameObject SeerPanel;
    //------------------Hunter------------------------
    public GameObject HunterPanel;
    public GameObject VillagerPanel;
    public GameObject SelectPlayerPanel; 
    // This is only set on client to the ID of the local player
    public int localplayerID; 
    public GameLogic gameLogic;
    public List<int> occupiedPlayerID;
    //---------------------general-------------------
    public int target;
    // Start is called before the first frame update
    void Start()
    {
        
    } 
    //called by Host and client button
     
    public IEnumerator SetSeatsWithDelay()
    {

        yield return new WaitForSeconds(1.0f); // Wait for 2 seconds 
        foreach (GameObject avatar in enabledAvatars)
        {
            avatar.SetActive(true);
        }
    }
    public void AddEnabledAvatars(int i) {
        enabledAvatars.Add(avatarList[i-1]);
    }
    void RpcReceiveSeatInfo() {
        //send all seat Info to 
        foreach (GameObject avatar in avatarList) {
            if (avatar.activeSelf == true) { 
                
            }
        }
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
    //-------------------------Werewolf-------------------------
    //-------------------------Werewolf-------------------------
    //Called by kill button in ww panel
    public void OnClickKillPlayer() {
        //The ww clicked on kill button
        //show Panel to let him select player
        SelectPlayerPanel.SetActive(true);
        WerewolfPanel.SetActive(false);
        UnToggleKillButtons();
    }
    //called by any player moves that need to select a player as target:
    // witch, seer, ww, hunter
    public void OnClickSelectPlayer() 
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("Button clicked: " + buttonName[buttonName.Length - 1]);
        target = int.Parse(buttonName[buttonName.Length - 1].ToString());
        int i = 0;
        foreach (Outline outline in SeatOutlineList) {
            if (i + 1 == target)
            {
                outline.enabled = !outline.enabled;
            }
            else {
                outline.enabled = false;
            }
            i++;
        }
    }
    //-------------------------General-------------------------
    //-------------------------General------------------------- 
    void AddWhoDied() {
        //called when ww kill and witch poison
        gameLogic.playerWhoDied.Add(target);
    } 
    void RemoveWhoDied() {//called when someone is saved
        gameLogic.playerWhoDied = new List<int>();
    }
    //----------------------Selection Panel------------------------------
    //----------------------Selection Panel------------------------------
    //called by confirm button in select panel
    public void OnClickConfirm() 
    {
        //check identity
        if (gameLogic.playerRole == PlayerRole.WEREWOLF)
        {
            AddWhoDied();
            WerewolfPanel.SetActive(true);
            SelectPlayerPanel.SetActive(false);
            wwInfo.text = "Note in each turn only the first werewolf can use the skill, please communicate with your teammates \n player " + gameLogic.playerID + " killed player " + target;
            gameLogic.PlayCloseEyesAudio();
            //StartCoroutine(SetTurnWithDelay(GameLogic.PlayerTurn.WitchTurn));
        }
        else if (gameLogic.playerRole == PlayerRole.SEER)
        {

        }
        else if (gameLogic.playerRole == PlayerRole.Witch)
        {//Must be when witch wants to posion someone
            AddWhoDied();
            WitchPanel.SetActive(true);
            SelectPlayerPanel.SetActive(false);
            gameLogic.PlayCloseEyesAudio();
            //StartCoroutine(SetTurnWithDelay(GameLogic.PlayerTurn.SeerTurn));
            poisonButton.interactable = false;
        }
        else if (gameLogic.playerRole == PlayerRole.Hunter)
        {
        }
    }
    //-------------------------Witch-------------------------
    //-------------------------Witch-------------------------
    // called by save button of witch panel
    public void OnClickSave() {
        RemoveWhoDied();
        
        gameLogic.UpdateAlivePlayer();
        gameLogic.PlayCloseEyesAudio();
        //StartCoroutine(SetTurnWithDelay(GameLogic.PlayerTurn.SeerTurn));
    }
    public void OnClickPoison() {
        SelectPlayerPanel.SetActive(true);
        WitchPanel.SetActive(false);
    }
    public void OnClickWitchSkip() {
        gameLogic.PlayCloseEyesAudio();
        //StartCoroutine(SetTurnWithDelay(GameLogic.PlayerTurn.SeerTurn));
    }
    public void UpdateWitchText() {
        if (saveButton.interactable == true)
        {
            witchInfo.text = "Player" + gameLogic.playerWhoDied[0] + "is dead";
        }
        else {
            witchInfo.text = "Player ? is dead";
        }
    }
    IEnumerator SetTurnWithDelay(GameLogic.PlayerTurn turn)
    {
          
        yield return new WaitForSeconds(10.0f); // Wait for 2 seconds
        if (turn == PlayerTurn.WitchTurn)
        {
            saveButton.gameObject.SetActive(true);
            witch_skipButton.gameObject.SetActive(true);
            poisonButton.gameObject.SetActive(true);
        }
        else if (turn == PlayerTurn.SeerTurn)
        {

        }
        else if (turn == PlayerTurn.HunterTurn)
        {
        }
        else if (turn == PlayerTurn.Campaign)
        {
        }
        else if (turn == PlayerTurn.Vote)
        {
        }
        else if (turn == PlayerTurn.WerewolfTurn)
        { 
        }
        // Code after the delay (line n)
        gameLogic.SetTurn(turn);
    } 
    void UnToggleKillButtons()
    {//untoggle ww kill button if someone already used that 
        Debug.Log("Untoggle called");
        if (gameLogic.playerRole == PlayerRole.WEREWOLF) {
            killButton.interactable = false;
        } 
    }
    void UnToggleSaveButton() { 
    
    } 
    void ToggleKillButtons() {

        if (gameLogic.playerRole == PlayerRole.WEREWOLF) {
            killButton.interactable = true;
        }
        else if (gameLogic.playerRole == PlayerRole.SEER) { }
        else if (gameLogic.playerRole == PlayerRole.Witch) { }
        else if (gameLogic.playerRole == PlayerRole.Hunter) { }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
