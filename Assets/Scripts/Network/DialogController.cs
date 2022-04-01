using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Transform dialog;
    public Transform dialogText;

    public void SetText(string txt) {
        dialogText.GetComponent<Text>().text = txt;
    }
    public void EnableDialog(bool enable){
        dialog.gameObject.SetActive(enable);
    }
    public bool IsEnabled()
    {
        return dialog.gameObject.activeSelf;
    }
}
