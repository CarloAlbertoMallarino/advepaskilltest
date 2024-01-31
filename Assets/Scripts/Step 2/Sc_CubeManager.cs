using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_CubeManager : MonoBehaviour
{
    [SerializeField] private List<Sc_Cube> cubeObjs = new List<Sc_Cube>();
    [SerializeField] private Sc_JsonReader jsonReader;

    private CubeListData cubesData = new CubeListData();

    void Start()
    {
        StartCoroutine(WaitForJsonDataValidation());
    }

    //to avoid null reference I wait for the data collection before deserialize the json
    private IEnumerator WaitForJsonDataValidation()
    {
        yield return new WaitUntil(() => jsonReader.GetDataCollected);

        cubesData = JsonUtility.FromJson<CubeListData>(jsonReader.GetJsonResult);
        print(cubesData);
        if (cubesData != null)
        {
            for (int i = 0; i < cubeObjs.Count; i++)
            {
                cubeObjs[i].InitCube(cubesData.cubecharacters[i]);
            }
        }
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
public class CubeListData
{
    public List<Cubecharacter> cubecharacters;
}
