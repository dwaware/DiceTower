using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState STATE;
    public GameState STATE_PREV;
    public static event Action<GameState> OnGameStateChanged;
    public enum GameState {
        IDLE,
        SELECT,
        ROLL
    };
    public GameObject dicePool;
    public int maxDice;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(IdleWhileLoading());
    }

    public void UpdateGameState(GameState _newState)
    {
        this.STATE_PREV = this.STATE;
        this.STATE = _newState;

        switch (_newState)
        {
            case GameState.IDLE:
                break;
            case GameState.SELECT:
                HandleSelecting();
                break;
            case GameState.ROLL:
                HandleRolling();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(_newState), _newState, null);
        }

        OnGameStateChanged?.Invoke(_newState);
    }
    private void HandleSelecting()
    {
        Debug.Log("Selecting!");
    }

    private void HandleRolling()
    {
        Debug.Log("Rolling!");
    }

    private IEnumerator IdleWhileLoading()
    {
        yield return new WaitForSeconds(2f);
        UpdateGameState(GameState.SELECT);
    }
}
