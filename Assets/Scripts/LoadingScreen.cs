using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class LoadingScreen : MonoBehaviour
{
    public TextMeshProUGUI TitleText;
    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameManager.GameState obj)
    {
        if (obj == GameManager.GameState.SELECT)
        {
            Debug.Log("Fade the title!");
            TitleText.DOFade(0f, 2f);
        }
    }
}
