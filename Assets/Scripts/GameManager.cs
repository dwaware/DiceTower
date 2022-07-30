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
        LOADING,
        SELECTING,
        ROLLING
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
            case GameState.LOADING:
                break;
            case GameState.SELECTING:
                HandleSelecting();
                break;
            case GameState.ROLLING:
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
        yield return new WaitForSeconds(0.5f);
        UpdateGameState(GameState.SELECTING);
    }
}
