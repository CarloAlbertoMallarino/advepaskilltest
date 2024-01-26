using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Cube : MonoBehaviour
{
    [SerializeField]private int ID;
    [SerializeField] private string color;
    [SerializeField] private string cubeName;

    private Sc_CubeInfos cubeInfos;
    private MeshRenderer cubeRenderer;

    private void Awake()
    {
        cubeInfos = GetComponentInChildren<Sc_CubeInfos>();
        cubeRenderer = GetComponent<MeshRenderer>();
    }

    public void InitCube(Cubecharacter c)
    {
        StoreCubeProperties(c);
        ChangeCubeColorMaterial();
        InformUI();
    }

    private void StoreCubeProperties(Cubecharacter _c)
    {
        this.ID = _c.id;
        this.color = _c.color;
        this.cubeName = _c.name;
    }
    private void InformUI()
    {
        cubeInfos.InitDataInUI(ID, color, cubeName);
    }

    private void ChangeCubeColorMaterial()
    {
        Color parsedColor;

        if(ColorUtility.TryParseHtmlString(color, out parsedColor))
        {
            cubeRenderer.material.color = parsedColor;
        }
        else
        {
            Debug.LogError($"Color: {color} is invalid");
        }
    }
}
