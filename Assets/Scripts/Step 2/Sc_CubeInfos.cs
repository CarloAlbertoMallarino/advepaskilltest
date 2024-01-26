using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sc_CubeInfos : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI idText;
    [SerializeField] private TextMeshProUGUI colorText;
    [SerializeField] private TextMeshProUGUI nameText;


    public void InitDataInUI(int id, in string color, in string name)
    {
        idText.text = id.ToString();
        colorText.text = color;
        nameText.text = name;
    }

}
