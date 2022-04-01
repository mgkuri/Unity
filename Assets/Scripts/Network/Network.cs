using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


/// Class to http client calls to the server .
public class Network : MonoBehaviour
{
    //public variables statements 
    public Transform responseText;
    public DialogController dialogController;
    public string get = "getTime";


    //method to start request coroutine
    public void getDate() {
        StartCoroutine(requestDate());
        
    }

    //coroutine to manage request and response
    IEnumerator requestDate()
    {
        UnityWebRequest request = new UnityWebRequest("http://127.0.0.1:3000/"+get);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Show results as text
            string response = request.downloadHandler.text;
            this.responseText.GetComponent<Text>().text = response;
            //desactivate dialog
            if(dialogController.IsEnabled()) dialogController.EnableDialog(false);
        }
        else
        {
            string errorMsg = "unknowError";
            switch (request.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + request.error);
                    errorMsg = request.error;
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + request.error);
                    errorMsg = request.error;
                    break;
                default:
                    errorMsg = "no implemented error";
                    break;

            }
            dialogController.EnableDialog(true);
            dialogController.SetText(errorMsg);
        }
    }
}
