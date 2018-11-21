using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighLightImage : MonoBehaviour {

    Image image_ref;
    float time_counter = 0.0f;
    float alpha = 1.0f;

	// Use this for initialization
	void Start () {
        image_ref = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        time_counter += Time.deltaTime;
        image_ref.color = new Color(1.0f, 1.0f, 1.0f, alpha - Mathf.Abs((Mathf.Sin(time_counter) * 0.25f)));
	}
}
