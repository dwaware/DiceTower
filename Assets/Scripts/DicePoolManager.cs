using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DicePoolManager : MonoBehaviour
{
    public GameObject die;
    public GameObject dicePool;
    public List<GameObject> dice;
    public float totalVelocity;
    public CanvasGroup addCG;
    public CanvasGroup subCG;
    public CanvasGroup rollCG;
    public TextMeshProUGUI totalText;
    public CanvasGroup totalTextCG;

    public void IncrementDice(int _amount)
    {
        var xOff = dice.Count % 2;
        var yOff = 1.25f * Mathf.FloorToInt(dice.Count / 4);
        var zOff = dice.Count % 4;

        if (_amount == 1 && dice.Count < GameManager.Instance.maxDice)
        {
            var posVec = transform.position + new Vector3(2 + xOff, 6.25f + yOff, -1 - zOff);
            var rotVec = new Vector3(UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 360f));

            GameObject _die = Instantiate(die, posVec, Quaternion.Euler(rotVec));
            _die.transform.SetParent(dicePool.transform);

            var offsetColor = Random.Range(0, 2);
            var offsetR = 0f;
            var offsetG = 0f;
            var offsetB = 0f;
            if (offsetColor == 0) { offsetR = 0.25f; }
            if (offsetColor == 0) { offsetG = 0.25f; }
            if (offsetColor == 0) { offsetB = 0.25f; }
            var _matColor = new Color(Random.Range(0.5f+offsetR, 1f), Random.Range(0.5f+offsetG, 1f), Random.Range(0.5f+offsetB, 1f), 1);
            _die.GetComponent<Renderer>().material.SetColor("_Color", _matColor);

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
            foreach (GameObject _die in dice)
            {
                var _dieVel = _die.GetComponent<Rigidbody>().velocity.magnitude;
                if (_dieVel == 0)
                {
                    _die.GetComponent<DieController>().onTable = true;
                }
                totalVelocity += _dieVel;
            }
            if (totalVelocity == 0)
            {
                var diceTotal = 0;
                var cockedDie = false;
                foreach (GameObject _die in dice)
                {
                    var upperSideVal = _die.GetComponent<DieController>().UpperSideValue;
                    diceTotal += upperSideVal;
                    if (upperSideVal == -1)
                    {
                        cockedDie = true;
                    }
                }
                if (cockedDie == true)
                {
                    totalText.text = "TOTAL:  Cocked, roll again.";
                }
                else
                {
                    totalText.text = "TOTAL:  " + diceTotal;
                }
                totalTextCG.DOFade(1f, 0.5f);
                if (dice.Count < GameManager.Instance.maxDice)
                {
                    addCG.interactable = true;
                }
                subCG.interactable = true;
                rollCG.interactable = true;
                GameManager.Instance.UpdateGameState(GameManager.GameState.SELECTING);
                
            }
        }
    }
}