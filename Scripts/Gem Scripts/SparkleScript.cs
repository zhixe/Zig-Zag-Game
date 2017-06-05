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
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

	/* Update is called once per frame
	void Update () {
		
	}*/
}
