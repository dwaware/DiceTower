using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicePoolButtonController : MonoBehaviour
{
    public int incrementAmount;
    public Button incrementButton;
    public Button otherButton;
    public CanvasGroup incCG;
    public CanvasGroup othCG;

    public void Start()
    {
        incrementButton.onClick.AddListener(HandleBtnClicked);
        if (incrementAmount == -1)
        {
            incCG.interactable = false;
        }
    }

    public void HandleBtnClicked()
    {
        GameManager.Instance.dicePool.GetComponent<DicePoolManager>().IncrementDice(incrementAmount);
        var numDice = GameManager.Instance.dicePool.GetComponent<DicePoolManager>().dice.Count;

        if (incrementAmount == 1)
        {
            if (numDice < GameManager.Instance.maxDice)
            {
                incCG.interactable = true;
            }
            else
            {
                incCG.interactable = false;
            }
            othCG.interactable = true;
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
            }
            othCG.interactable = true;
        }
    }
}
