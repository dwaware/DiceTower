using System;
using System.Collections.Generic;
using UnityEngine;

public class DieController: MonoBehaviour
{
    public int UpperSideValue;

    public Vector3 startPos;
    public Quaternion startRot;

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
        if (obj == GameManager.GameState.ROLLING)
        {
            if (GameManager.Instance.STATE_PREV == GameManager.GameState.ROLLING) {
                transform.position = startPos;
                startRot = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 360f)));
                transform.rotation = startRot;
                rb.velocity = Vector3.zero;
                rb.rotation = Quaternion.Euler(Vector3.zero);
            }
            Debug.Log("Roll die:  " + name);
            rb.constraints = RigidbodyConstraints.None;
            float randVel = UnityEngine.Random.Range(-1, 0);
            rb.velocity = new Vector3(0, randVel, 0);
        }
    }

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;

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