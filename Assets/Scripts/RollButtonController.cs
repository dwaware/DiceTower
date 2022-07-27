using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollButtonController : MonoBehaviour
{
    public Button rollButton;

    public void Start()
    {
        rollButton.onClick.AddListener(HandleBtnClicked);
    }

    private void HandleBtnClicked()
    {
        Debug.Log("You clicked the roll button:  " + rollButton.name);
        GameManager.Instance.UpdateGameState(GameManager.GameState.ROLL);
    }
}
