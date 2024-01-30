using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Sc_JsonReader : MonoBehaviour
{
    [SerializeField] private string URL;
    private string result;
    private bool dataCollected = false;

    void Awake()
    {
        StartCoroutine(Read());
    }

    private IEnumerator Read()
    {
        UnityWebRequest request = UnityWebRequest.Get(URL);

        yield return request.SendWebRequest();

        if(request.result != UnityWebRequest.Result.Success)
            Debug.LogError(request.error);
        else
        {
            result = request.downloadHandler.text;
            dataCollected = true;
        }
        
        request.Dispose();
    }

    public string GetJsonResult { get { return result; } }
    public bool GetDataCollected { get { return dataCollected; } }


}




