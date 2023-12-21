using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LobbyUI : MonoBehaviour
{
    public MainGameUI mainGame;
    int localplayerID;
    public List<GameObject> EmptySeatList = new List<GameObject>();
    public List<GameObject> avatarList;
    private List<GameObject> enabledAvatars = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnClickSeat() {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        //set player ID
        localplayerID = int.Parse(buttonName[buttonName.Length - 1].ToString());
        mainGame.localplayerID = localplayerID;
        disableSeatButton();//Player are not allowed to change seat
        //Enable avatar for myself
        mainGame.AddEnabledAvatars(localplayerID);
        StartCoroutine(mainGame.SetSeatsWithDelay());
        //Enable avatar for all other players
        //Disable the current seat

    }
    public void disableSeatButton() {
        for (int i = 0; i <= EmptySeatList.Count - 1; i++)
        {
            Debug.Log(i);
            Button SeatButton = EmptySeatList[i].GetComponent<Button>();
            SeatButton.interactable = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
