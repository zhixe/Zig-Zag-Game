using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    [HideInInspector]
    public bool gamePlaying;

    [SerializeField]
    private GameObject tile;
    private Vector3 currentTilePosition;
	// Use this for initialization
	void Awake () {
        MakeSingleton();
        currentTilePosition = new Vector3(-2, 0, 2);
	}

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            CreateTiles();
        }
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

    void CreateTiles ()
    {
        Vector3 newTilePosition = currentTilePosition;
        int rand = Random.Range(0, 100);

        if (rand < 50)
        {
            newTilePosition.x -= 1f;
        }else
        {
            newTilePosition.z += 1f;
        }
        currentTilePosition = newTilePosition;
        Instantiate(tile, currentTilePosition, Quaternion.identity);
    }
}
