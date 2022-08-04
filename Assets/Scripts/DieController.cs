using System;
using System.Collections.Generic;
using UnityEngine;

public class DieController: MonoBehaviour
{
    public int UpperSideValue;

    public Vector3 startPos;

    public Rigidbody rb;
    public Vector3Int ReferencePips;
    private Vector3Int OpposingPips;
    readonly List<int> FacePips = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
    public bool onTable;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1f;

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
            if (GameManager.Instance.STATE_PREV == GameManager.GameState.SELECTING) {
                transform.position = startPos;
                if (onTable == true)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 360f)));
                }
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

        rb.constraints = RigidbodyConstraints.FreezePosition;
        UpperSideValue = 0;
        OpposingPips = 7 * Vector3Int.one - ReferencePips;
        onTable = false;
    }

    void PlayAudio()
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Table")
        {
            Debug.Log("Collided with:  " + collision.gameObject.name);
            PlayAudio();
        }
    }

    void Update() {
        if (rb.velocity.magnitude > 0)
        {
            if (Vector3.Cross(Vector3.up, transform.right).magnitude < 0.1f) //x
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
            else if (Vector3.Cross(Vector3.up, transform.up).magnitude < 0.1f) //y
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
            else if (Vector3.Cross(Vector3.up, transform.forward).magnitude < 0.1f) //z
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
            else
            {
                UpperSideValue = -1;
            }
        }
    }
}