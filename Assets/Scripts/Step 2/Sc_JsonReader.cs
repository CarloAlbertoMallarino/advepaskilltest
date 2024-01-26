using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Sc_JsonReader : MonoBehaviour
{
    //[SerializeField] private CubeList cubes = new CubeList();
    [SerializeField] private CubeList cubes = new CubeList();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Read());
    }

    private IEnumerator Read()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://dev.advepa.com/skilltest/getCharacter/index.json");

        yield return request.SendWebRequest();

        if(request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string result = request.downloadHandler.text;
            cubes = JsonUtility.FromJson<CubeList>(result);
            
            Debug.Log(result);
        }

        request.Dispose();
    }


}

[System.Serializable]
public class Cubecharacter
{
    public int id;
    public string color;
    public string name;
}

[System.Serializable]
public class CubeList
{
    public List<Cubecharacter> cubecharacters;
}


