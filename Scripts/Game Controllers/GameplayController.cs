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
    private AudioSource audioSource;

    [SerializeField]
    private Material tileMat;

    [SerializeField]
    private Light dayLight;

    private Camera mainCamera;

    private bool CamColorLerp;

    private Color cameraColor;

    private Color[] tileColor_Day;
    private Color tileColor_Night;
    private int tileColor_Index;

    private Color tileTrueColor;

    private float timer;
    private float timerInterval = 5f;

    private float camLerpTimer;
    private float camLerpInterval = 1f;

    private int direction = 1;

    // Use this for initialization
    void Awake () {
        MakeSingleton();
        audioSource = GetComponent<AudioSource>();
        currentTilePosition = new Vector3(-2, 0, 2);
        mainCamera = Camera.main;
        cameraColor = mainCamera.backgroundColor;
        tileTrueColor = tileMat.color;
        tileColor_Index = 0;
        tileColor_Day = new Color[3];
        tileColor_Day[0] = new Color(10 / 256f, 139 / 256f, 203 / 256f);
        tileColor_Day[1] = new Color(10 / 256f, 200 / 256f, 20 / 256f);
        tileColor_Day[2] = new Color(220 / 256f, 170 / 256f, 45 / 256f);
        tileColor_Night = new Color(0, 8 / 256f, 11 / 256f);
        tileMat.color = tileColor_Day[0];
    }

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            CreateTiles();
        }
    }

    void Update()
    {
        CheckLerpTimer();
    }

    void OnDisabble ()
    {
        instance = null;
        tileMat.color = tileTrueColor;
        //0A8ACAFF
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

    void CheckLerpTimer ()
    {
        timer += Time.deltaTime;
        if (timer > timerInterval)
        {
            timer -= timerInterval;
            CamColorLerp = true;
            camLerpTimer = 0f;
        }

        if (CamColorLerp)
        {
            camLerpTimer += Time.deltaTime;
            float percent = camLerpTimer / camLerpInterval;
            if (direction == 1)
            {
                mainCamera.backgroundColor = Color.Lerp(cameraColor, Color.black, percent);
                tileMat.color = Color.Lerp(tileColor_Day[tileColor_Index], tileColor_Night, percent);
                dayLight.intensity = 1f - percent;
            } else
            {
                mainCamera.backgroundColor = Color.Lerp(Color.black, cameraColor, percent);
                tileMat.color = Color.Lerp(tileColor_Night, tileColor_Day[tileColor_Index], percent);
                dayLight.intensity = percent;
            }

            if (percent > 0.98f)
            {
                camLerpTimer = 1f;
                direction *= -1;
                CamColorLerp = false;

                if (direction == -1)
                {
                    tileColor_Index = Random.Range(0, tileColor_Day.Length);
                }
            }
        }
    }

    public void ActiveTileSpawner()
    {
        StartCoroutine(SpawnNewTiles());
    }

    public void PlayCollectableSound ()
    {
        audioSource.Play();
    }

    IEnumerator SpawnNewTiles()
    {
        yield return new WaitForSeconds(0.3f);
        CreateTiles();

        if (gamePlaying)
        {
            StartCoroutine(SpawnNewTiles());
        }
    }
}
