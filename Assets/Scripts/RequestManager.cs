using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace Core.Request
{
    public class RequestManager : MonoBehaviour
    {
        private const string API_KEY = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI4NTRmOGM1MC1hOTZlLTAxM2EtYmUxNy0yNTg4Y2U4MDc3ZWYiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjUxMTg0MDc5LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InRvcnJlLXRlc3RpbmcifQ.WG9htSUpWOeFY1xuHrDbVKCOP0Byit18iElPaLXZWLc";
        
        public static IEnumerator MakeRequest(string endpoint, string param = "", System.Action<string> callback = null)
        {
            string response = "";
            UnityWebRequest webRequest = UnityWebRequest.Get(endpoint + param);
            webRequest.SetRequestHeader("Authorization", API_KEY);
            webRequest.SetRequestHeader("accept", "application/vnd.api+json");
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    response = ": Error: \n" + webRequest.error;
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    response = ": Error: \n" + webRequest.error;
                    Debug.LogError(": Error: \n" + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    response = ": HTTP Error: \n" + webRequest.error;
                    Debug.LogError(": HTTP Error: \n" + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:                    
                    response = webRequest.downloadHandler.text;                    
                    break;
            }
            yield return new WaitForSeconds(2f);
            if(callback!=null){
                callback?.Invoke(response);
            }
        }
    }
}

