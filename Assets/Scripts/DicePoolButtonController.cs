using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicePoolButtonController : MonoBehaviour
{
    public int incrementAmount;
    public Button incrementButton;
    public CanvasGroup incCG;
    public CanvasGroup othCG;
    public CanvasGroup rollCG;

    public void Start()
    {
        incrementButton.onClick.AddListener(HandleBtnClicked);
        if (incrementAmount == -1)
        {
            incCG.interactable = false;
            rollCG.interactable = false;
        }
    }

    public void HandleBtnClicked()
    {
        GameManager.Instance.dicePool.GetComponent<DicePoolManager>().IncrementDice(incrementAmount);
        var numDice = GameManager.Instance.dicePool.GetComponent<DicePoolManager>().dice.Count;
        GameManager.Instance.UpdateGameState(GameManager.GameState.SELECTING);

        if (incrementAmount == 1)
        {
            if (numDice < GameManager.Instance.maxDice)
            {
                incCG.interactable = true;
                rollCG.interactable = true;
            }
            else
            {
                incCG.interactable = false;
            }
            othCG.interactable = true;
            rollCG.interactable = true;
        }
        if (incrementAmount == -1)
        {
            if (numDice > 0)
            {
                incCG.interactable = true;
            }
            else
            {
                incCG.interactable = false;
                rollCG.interactable = false;
            }
            othCG.interactable = true;
        }
    }
}
