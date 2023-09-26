using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtilities;
using System.Linq;
using Mirror;
using Unity.VisualScripting;

public enum PlayerRole
{
    WEREWOLF,
    VILLAGER,
    SEER,
    Witch,
    Hunter
}
public class GameLogic : NetworkBehaviour
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
        Campaign,//竞选警长
        Discussion,
        Vote
    }
    public AudioSource THQBY;//天黑请闭眼...狼人击杀目标
    public PlayerTurn cur_Turn;
    public int playerID;
    public PlayerRole playerRole;
    /// <summary>
    /// When the gameobject enables We start the game
    /// </summary>
    public void OnEnable()
    { 
        cur_Turn = PlayerTurn.WerewolfTurn;
        StartCoroutine(FinalStateMachine());
        
    }
    public override void OnStartClient()
    {
        base.OnStartClient();
        playerRole = roles[playerID-1];
    }
    public override void OnStartServer(){
        //roles = ShuffleRoles(); not shuffle for testing
        RPCshufflecards(roles);//let client get the same card distribution

    }
    //called by Gamestart button in Lobbypanel 
    public void PlayTHQBY() {
        if (isServer)
        {
            THQBY.PlayOneShot(THQBY.clip);
        }
    }
    [ClientRpc]
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
    IEnumerator FinalStateMachine()
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
    }

}
