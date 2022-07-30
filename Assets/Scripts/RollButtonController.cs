using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollButtonController : MonoBehaviour
{
    public Button rollButton;
    public CanvasGroup addCG;
    public CanvasGroup subCG;

    public void Start()
    {
        rollButton.onClick.AddListener(HandleBtnClicked);
    }

    private void HandleBtnClicked()
    {
        Debug.Log("You clicked the roll button:  " + rollButton.name);
        addCG.interactable = false;
        subCG.interactable = false;
        GameManager.Instance.UpdateGameState(GameManager.GameState.ROLLING);
    }
}
