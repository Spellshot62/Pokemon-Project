using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Battle}

public class GameController : MonoBehaviour
{

    [SerializeField] PlayerController playerController;
    [SerializeField] Camera worldCamera;
    [SerializeField] Camera battleCamera;

    GameState state;

    private void Start(){
        playerController.OnEncountered += StartBattle;
    }

    void StartBattle(){
        state = GameState.Battle;
        worldCamera.gameObject.SetActive(false);
        battleCamera.gameObject.SetActive(true);
    }

    private void Update(){
        if(state == GameState.FreeRoam){
            playerController.HandleUpdate();
        }
        
    }
}
