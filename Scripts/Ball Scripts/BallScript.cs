using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private Rigidbody myBody;
    private bool rollLeft;

    public float speed = 4f;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody>();
        rollLeft = true;
	}
	
	// Update is called once per frame
	void Update () {
        CheckInput();
	}

    void FixedUpdate ()
    {
        if (GameplayController.instance.gamePlaying)
        {
            if (rollLeft)
            {
                myBody.velocity = new Vector3(-speed, Physics.gravity.y, 0f);
            }
            else
            {
                myBody.velocity = new Vector3(0f, Physics.gravity.y, speed);
            }
        }
    }

    void CheckInput ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameplayController.instance.gamePlaying)
            {
                GameplayController.instance.gamePlaying = true;
                GameplayController.instance.ActiveTileSpawner();
            }
        }

        if (GameplayController.instance.gamePlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rollLeft = !rollLeft;
            }
        }
    }
}// Class













