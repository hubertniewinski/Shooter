using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {
    public Text result;
	// Use this for initialization
	void Start () {
        result.text = (UiText.Enemies + 1).ToString() + " Place";

    }
}
