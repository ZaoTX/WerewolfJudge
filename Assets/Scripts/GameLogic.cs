using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public enum PlayerTurn
    {
        WerewolfTurn,
        WitchTurn,
        SeerTurn,
        HunterTurn,
        Campaign,//¾ºÑ¡¾¯³¤
        Discussion,
        Vote
    }

    public PlayerTurn cur_Turn;
    /// <summary>
    /// When the gameobject enables We start the game
    /// </summary>
    public void OnEnable()
    { 
         cur_Turn = PlayerTurn.WerewolfTurn;
        StartCoroutine(FinalStateMachine());
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
