using System;
using System.Collections.Generic;
using UnityEngine;

public class DieController: MonoBehaviour
{
    public int UpperSideValue;

    public Rigidbody rb;
    public Vector3Int ReferencePips;
    private Vector3Int OpposingPips;
    readonly List<int> FacePips = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameManager.GameState obj)
    {
        if (obj == GameManager.GameState.ROLL)
        {
            Debug.Log("Roll die:  " + this.name);
            rb.constraints = RigidbodyConstraints.None;
            float randVel = UnityEngine.Random.Range(-2,0) - 2.5f;
            rb.velocity = new Vector3(0, randVel, 0);
        }
    }

    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        UpperSideValue = 0;
        OpposingPips = 7 * Vector3Int.one - ReferencePips;
    }

    void Update() {
        if (rb.velocity.magnitude > 0)
        {
            if (Vector3.Cross(Vector3.up, transform.right).magnitude < 0.5f) //x
            {
                if (Vector3.Dot(Vector3.up, transform.right) > 0)
                {
                    UpperSideValue = FacePips[ReferencePips.x];
                }
                else
                {
                    UpperSideValue = FacePips[OpposingPips.x];
                }
            }
            else if (Vector3.Cross(Vector3.up, transform.up).magnitude < 0.5f) //y
            {
                if (Vector3.Dot(Vector3.up, transform.up) > 0)
                {
                    UpperSideValue = FacePips[ReferencePips.y];
                }
                else
                {
                    UpperSideValue = FacePips[OpposingPips.y];
                }
            }
            else if (Vector3.Cross(Vector3.up, transform.forward).magnitude < 0.5f) //z
            {
                if (Vector3.Dot(Vector3.up, transform.forward) > 0)
                {
                    UpperSideValue = FacePips[ReferencePips.z];
                }
                else
                {
                    UpperSideValue = FacePips[OpposingPips.z];
                }
            }
        }
    }
}