using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerRole
{
    WEREWOLF,
    VILLAGER,
    SEER,
    Witch,
    Hunter
}
public class Player : MonoBehaviour
{
    public PlayerRole role;
    public GameObject PlayerUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
