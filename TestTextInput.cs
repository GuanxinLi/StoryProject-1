using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Input;

namespace AzureSuiteForUnity.CognitiveServices.BingSpeech
{
	public class TestTextInput : MonoBehaviour {
		// Use this for initialization
		public SpeechAPICall call;

		void Start () {
			//Debug.Log(UnityEngine.Input.GetJoystickNames ());
		}

	
		// Update is called once per frame
		void Update () {
			if(Input.GetKeyDown (KeyCode.Space)) {
				Debug.Log ("Pressed");
				BingSpeechAPIManager.Instance.RecognizeClip();
			}

		}
	}
}