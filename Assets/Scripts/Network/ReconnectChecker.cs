using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReconnectChecker : MonoBehaviour
{
    public GameObject MqttConnection;
    public float waitforseconds=3;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void RestartConnection()
    {
        // Your code before the wait...

        // Wait for 4 seconds 

        MqttConnection.SetActive(true);
        // Your code after the wait...
    }
    // Update is called once per frame
    void Update()
    {

        if (!MqttConnection.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= waitforseconds)
            {
                // Perform actions after the delay
                Debug.Log("Try to reconnect");

                MqttConnection.SetActive(true);
                // Reset the timer for the next delay
                timer = 0f;
            }
        }
        else { 
        
        }
    }
}
