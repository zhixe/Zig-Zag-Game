using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    [HideInInspector]
    public bool gamePlaying;

	// Use this for initialization
	void Awake () {
        MakeSingleton();
	}

    void OnDisabble ()
    {
        instance = null;
    }
	
	// Update is called once per frame
	void MakeSingleton () {
		if (instance == null)
        {
            instance = this;
        }
	}
}
