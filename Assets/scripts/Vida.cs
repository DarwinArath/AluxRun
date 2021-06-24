using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public int saludInicial = 100; //salud inicial
    public int saludActual; //salud actual
    public Slider barraSlider; //barra Deslisante
    // Start is called before the first frame update
    public void Awake()
    {
        saludActual = saludInicial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDaño(int valorDaño){
    saludActual -= valorDaño;
    barraSlider.value = saludActual;

    if(saludActual <= 0)
        GameOver.show ();
     
    }
}
