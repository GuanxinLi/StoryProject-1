using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace AzureSuiteForUnity.CognitiveServices.BingSpeech
{
    public class BingSpeechAPIManager : CognitiveServicesBehaviour<BingSpeechAPIManager>, ICognitiveServicesBehaviour
    {
        //Input_Listeners IPL;
        private IBingSpeechAPI _bingSpeechAPI { get; set; }
		public static BingSpeechAPIManager Instance;
        public AudioClip audioGenerated;
		string APIKey = "b386e0a592d34f20b7fbd43cbd49aec1"; // 94c91aeef0af42ef944e988f520514fd

        public SpeechAPICall apiCall;

        public string generatedJSON;

		void Awake(){
			Instance = this;
		}

        public void Start()
        {
            _bingSpeechAPI = CognitiveServicesServiceFactory.Instance.GetBingSpeechAPI(APIKey);
            //IPL = Singleton_Service.GetSingleton<Input_Listeners>();
            //new BingSpeechAPI("94c91aeef0af42ef944e988f520514fd", this);

            _bingSpeechAPI.OnRecognise += _bingSpeechAPI_OnRecognise;
        }

        private void Update()
        {

        }

		public void RecognizeClip(){
			_bingSpeechAPI.RecogniseAsync (_audioToRecognise);
		}

        private void _bingSpeechAPI_OnRecognise(IBingSpeechAPI sender, RecogniseEventArgs args)
        {
            generatedJSON = args.JsonResponse;
            if (generatedJSON != null)
            {
                apiCall.Convert(generatedJSON);
            }

        }

        private void _bingSpeechAPI_OnTextToSpeech(IBingSpeechAPI sender, TextToSpeechEventArgs args)
        {
            Debug.Log("Got response");
            audioGenerated = args.GeneratedAudio;
        }

        public void RecordAndProcess(int seconds)
        {
            StartCoroutine(RecordSeconds(seconds));
        }

        public AudioClip _audioToRecognise;
        private int _RATE = 16000;
        private int _SECONDS = 3;
        private AudioClip _recordingClip;

        IEnumerator RecordSeconds(int seconds)
        {
            Debug.Log("Recording... ");
            _recordingClip = Microphone.Start(null, false, seconds, _RATE);

            Debug.Log("Recording... STARTED");
            yield return new WaitForSeconds(seconds);
            Debug.Log("Recording... DONE");

            // Write the audio to disk
            Debug.Log("Saving...");
            //var wavData = new WavData(_recordingClip);
            //wavData.Save("c:\\projects\\vaughan\\test.wav");

            _bingSpeechAPI.RecogniseAsync(_recordingClip);
            Debug.Log("Saving... DONE");
        }
    }

}