using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlNivel : MonoBehaviour
{
    public void Lv3(){
        SceneManager.LoadScene("Nivel 03");
    }

    public void Menu(){
        SceneManager.LoadScene("MenuPrincipal");
    }
}
