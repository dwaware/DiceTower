using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePoolManager : MonoBehaviour
{
    public GameObject die;
    public GameObject dicePool;
    public List<GameObject> dice;
    public float totalVelocity;
    public CanvasGroup addCG;
    public CanvasGroup subCG;
    public CanvasGroup rollCG;

    public void IncrementDice(int _amount)
    {
        var yOff = Mathf.FloorToInt(dice.Count / 4);
        var xOff = dice.Count % 2 - yOff % 2;
        var zOff = dice.Count % 4;

        if (_amount == 1 && dice.Count < GameManager.Instance.maxDice)
        {
            var posVec = new Vector3(2 + xOff, 8 + yOff, -1 - zOff);
            var rotVec = new Vector3(UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 360f));
            GameObject _die = Instantiate(die, posVec, Quaternion.Euler(rotVec));
            _die.transform.SetParent(dicePool.transform);
            var _name = dice.Count + 1;
            _die.name = "Die " + _name.ToString();
            dice.Add(_die);
        }
        if (_amount == -1 && dice.Count > 0)
        {
            var diceCount = dice.Count - 1;
            Destroy(dice[diceCount]);
            dice.RemoveAt(diceCount);
            
        }
    }

    public void Update()
    {
        if (GameManager.Instance.STATE == GameManager.GameState.ROLLING)
        {
            var totalVelocity = 0f;
            var diceTotal = 0;
            foreach (GameObject _die in dice)
            {
                totalVelocity += _die.GetComponent<Rigidbody>().velocity.magnitude;
                diceTotal += _die.GetComponent<DieController>().UpperSideValue;
                if (Mathf.Approximately(totalVelocity, 0f))
                {
                    Debug.Log("Done rolling!  Total is:  " + diceTotal);
                    addCG.interactable = true;
                    subCG.interactable = true;
                    rollCG.interactable = true;
                    GameManager.Instance.UpdateGameState(GameManager.GameState.SELECTING);
                }
            }
        }
    }
}