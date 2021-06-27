using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class comandomenu : MonoBehaviour
{
    public AudioSource clip;
    public GameObject tutorial;
    public GameObject creditos;

    //metodo para comenzar el juego
    public void CargarEscena(string NombreDeEscena){
    	SceneManager.LoadSceneAsync(NombreDeEscena);
    }

    public void tutoria(){
        tutorial.SetActive(true);
    }

    public void credito(){
        creditos.SetActive(true);
    }

    public void regresar(){
            //Aplication.Quit();
            SceneManager.LoadScene("MenuPrincipal");        
        }

    //metodo para salir
    public void Salir(){
    	Application.Quit();
    	//Debug.Log("Has Salido");
    }

    public void Audio(){
            clip.Play();
        }

    
}
