using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour {

    [SerializeField]
    private GameObject sparkleFX;

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Ball")
        {
            Instantiate(sparkleFX, transform.position, Quaternion.identity);
            GameplayController.instance.PlayCollectableSound();
            gameObject.SetActive(false);
        }
    }

    /* Use this for initialization
	void Start () {
		
	}
	
    Update is called once per frame
	void Update () {
		
	}*/
}
