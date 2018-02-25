using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AzureSuiteForUnity.CognitiveServices;
using UnityEngine.Events;

//build json class structure
public class Words{
	public Header header;
}

public class Header{
	public string name;
}

namespace AzureSuiteForUnity.CognitiveServices.BingSpeech
{
    public class SpeechAPICall : MonoBehaviour
    {
        //Input_Listeners IPL;
		Words input;

        private IBingSpeechAPI _bingSpeechAPI { get; set; }
		private string APIKey = "b386e0a592d34f20b7fbd43cbd49aec1";

        //public UnityEvent OnFire;
        //public UnityEvent OnWalls;
        //public UnityEvent OnDetect;

        void Start()
        {
            _bingSpeechAPI = CognitiveServicesServiceFactory.Instance.GetBingSpeechAPI(APIKey);
            //IPL = Singleton_Service.GetSingleton<Input_Listeners>();
            //wrapper = new Wrapper();
        }

        public void Convert(string json)
        {
            if (json == null)
            {
                return;
            }
            input = JsonUtility.FromJson<Words>(json);

            /*if (wrapper.Header.Lexical != null && !wrapper.Header.Status.ToLower().Equals("error"))
            {
                if (wrapper.Header.Lexical.ToLower().Contains("attack") && OnFire != null && float.Parse(wrapper.Results[0].Confidence) > 0.75f)
                {
                    Debug.Log("Attacking");
                    OnFire.Invoke();
                    //IPL.TriggerPulsedVibrationLeft(50, 0.01f, 0.01f, 3999);
                    //IPL.TriggerPulsedVibrationRight(50, 0.01f, 0.01f, 3999);
                }
                if ((wrapper.Header.Lexical.ToLower().Contains("secure") || wrapper.Header.Lexical.ToLower().Contains("block")) && OnWalls != null)
                {
                    Debug.Log("Defending");
                    OnWalls.Invoke();
                    //IPL.TriggerPulsedVibrationLeft(50, 0.01f, 0.01f, 3999);
                    //IPL.TriggerPulsedVibrationRight(50, 0.01f, 0.01f, 3999);
                }
                if ((wrapper.Header.Lexical.ToLower().Contains("detect") || wrapper.Header.Lexical.ToLower().Contains("search") || wrapper.Header.Lexical.ToLower().Contains("find")) && OnDetect != null && float.Parse(wrapper.Results[0].Confidence) > 0.75f)
                {
                    Debug.Log("Searching");
                    OnDetect.Invoke();
                    //IPL.TriggerPulsedVibrationLeft(50, 0.01f, 0.01f, 3999);
                    //IPL.TriggerPulsedVibrationRight(50, 0.01f, 0.01f, 3999);
                }
            }*/
        }
    }
}