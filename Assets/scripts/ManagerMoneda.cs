using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerMoneda : MonoBehaviour
{
    public Text MonedasTotal;
    public Text MonedasTomadas;

    private int MonedasTotaledEnNivel;
     // Start is called before the first frame update
    void Start()
    {
        MonedasTotaledEnNivel = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        MonedasTotal.text = MonedasTotaledEnNivel.ToString();
        MonedasTomadas.text = transform.childCount.ToString();
    }
}
