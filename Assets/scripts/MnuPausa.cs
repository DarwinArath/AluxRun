using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MnuPausa : MonoBehaviour
{
    public AudioSource clip;
    public GameObject optionsPanel;
 
  
            //Pausea el nivel
        public void OptionsPanel(){
            Time.timeScale = 0;
            optionsPanel.SetActive(true);
        }

        public void Return(){
            Time.timeScale = 1;
            optionsPanel.SetActive(false);
        }

        public void QuitGame(){
            //Aplication.Quit();
            SceneManager.LoadScene("MenuPrincipal");        
        }

        public void Audio(){
            clip.Play();
        }

        public void Lv1(){
        SceneManager.LoadScene("Nivel 01");
        Time.timeScale = 1;
            optionsPanel.SetActive(false);
    }

    public void Lv2(){
        SceneManager.LoadScene("Nivel 02");
        Time.timeScale = 1;
            optionsPanel.SetActive(false);
    }

    public void Lv3(){
        SceneManager.LoadScene("Nivel 03");
        Time.timeScale = 1;
            optionsPanel.SetActive(false);
    }
        
    
}
