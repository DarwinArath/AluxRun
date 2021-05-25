using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class comandomenu : MonoBehaviour
{
    //metodo para comenzar el juego
    public void CargarEscena(string NombreDeEscena){
    	SceneManager.LoadSceneAsync(NombreDeEscena);
    }

    //metodo para salir
    public void Salir(){
    	Application.Quit();
    	Debug.Log("Has Salido");
    }

    
}
