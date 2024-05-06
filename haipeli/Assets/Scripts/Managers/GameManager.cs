using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public gameStates currentGameState;

    public static GameManager instance;

    private Master controls;

    public Player playerController { get; set;}

    void Awake()
    {
        controls = new Master();
        
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    
    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        TogglePause();
    }

    public bool IsGamePlay()
    {
        return currentGameState == gameStates.Gameplay;
    }

    private void TogglePause()
    {
        if (controls.Game.Pause.triggered)
        {
            Debug.Log("Pause");
            if (currentGameState == gameStates.Gameplay)
            {
                currentGameState = gameStates.Pause;
            }
            else if (currentGameState == gameStates.Pause)
            {
                currentGameState = gameStates.Gameplay;
            }
        }
    }
}

