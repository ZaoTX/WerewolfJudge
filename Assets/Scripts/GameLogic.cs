using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using System.Linq;  

public enum PlayerRole
{
    WEREWOLF,
    VILLAGER,
    SEER,
    Witch,
    Hunter
}
public class GameLogic : MonoBehaviour
{
    public List<PlayerRole> roles
            = new List<PlayerRole> {
                    PlayerRole.WEREWOLF,PlayerRole.WEREWOLF,PlayerRole.WEREWOLF,
                    PlayerRole.Hunter,
                    PlayerRole.Witch,
                    PlayerRole.SEER,
                    PlayerRole.VILLAGER,PlayerRole.VILLAGER,PlayerRole.VILLAGER
            };//roles to be assigned
    public enum PlayerTurn
    {
        WerewolfTurn,
        WitchTurn,
        SeerTurn,
        HunterTurn,
        Campaign,//¾ºÑ¡¾¯³¤ 
        Vote
    }
    public AudioSource THQBY;//ÌìºÚÇë±ÕÑÛ...ÀÇÈË»÷É±Ä¿±ê
    public AudioSource witchAudio;//Å®Î×ÇëÕöÑÛ...¾Èor¶¾
    public AudioSource closeEyesAudio;//Å®Î×ÇëÕöÑÛ...¾Èor¶¾
    public PlayerTurn cur_Turn;
    public int playerID;
    public PlayerRole playerRole;
    public List<int> playerWhoDied = new List<int>();// Player who died tonight
    public List<int> playerWhoIsAlive = new List<int>{1,2,3,4,5,6,7,8,9};
    public MainGameUI gameUI;
    /// <summary>
    /// When the gameobject enables We start the game
    /// </summary>
    public void OnEnable()
    { 
        cur_Turn = PlayerTurn.WerewolfTurn;
        //StartCoroutine(FinalStateMachine());
    }

    public void UpdateAlivePlayer() {
        foreach (int i in playerWhoDied) { 
            playerWhoDied.Remove(i);
        }
    } 
    //called by Gamestart button in Lobbypanel 
    void PlayTHQBY() {
        THQBY.PlayOneShot(THQBY.clip);
    } 
    void PlayWitchAudio()
    {
        witchAudio.PlayOneShot(witchAudio.clip);
    } 
    public void PlayCloseEyesAudio()
    {
        closeEyesAudio.PlayOneShot(closeEyesAudio.clip);
    } 
    void PlaySeer() { 
        
    } 
    public void SetTurn(PlayerTurn playerTurn) {
         cur_Turn=playerTurn;
        if (playerTurn == PlayerTurn.WitchTurn)
        {
            PlayWitchAudio();
            
        }
        else if (playerTurn == PlayerTurn.SeerTurn)
        {

        }
        else if (playerTurn == PlayerTurn.HunterTurn)
        {
        }
        else if (playerTurn == PlayerTurn.Campaign)
        {
        }
        else if (playerTurn == PlayerTurn.Vote)
        {
        }
        else if (playerTurn == PlayerTurn.WerewolfTurn) {
            PlayTHQBY();
        }
    } 
    public void RPCshufflecards(List<PlayerRole> shuffledroles) {
        roles = shuffledroles;
    }
    public List<PlayerRole> ShuffleRoles()
    {
        // Create a random number generator
        System.Random random = new System.Random();
        List<PlayerRole> shuffledroles = roles.OrderBy(item => random.Next()).ToList();
        return shuffledroles;
    }  
   /* IEnumerator FinalStateMachine()
    {
        while (true)
        {
            switch (cur_Turn)
            {
                case PlayerTurn.WerewolfTurn:
                    
                    break;
                case PlayerTurn.WitchTurn:
                    break;
                case PlayerTurn.SeerTurn: 
                    break;
                case PlayerTurn.HunterTurn: 
                    break;
                case PlayerTurn.Campaign: 
                    break;
                case PlayerTurn.Discussion: 
                    break;
                case PlayerTurn.Vote: 
                    break;
            }
            yield return null;
        }
    }*/

}
