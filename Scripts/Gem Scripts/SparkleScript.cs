using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleScript : MonoBehaviour {

    // Use this for initialization
    void Start() {
        StartCoroutine(DeactiveAfterTime());
    }

    IEnumerator DeactiveAfterTime()
    {
        yield return new WaitForSeconds(0f);
        gameObject.SetActive(true);
    }

	/* Update is called once per frame
	void Update () {
		
	}*/
}
