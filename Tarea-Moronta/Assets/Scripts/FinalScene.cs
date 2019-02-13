using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    AudioSource audio;

    /// Aqui se instancia la escena final


    public TextMesh misPuntos;
    void Start()
    {
        misPuntos.text = CentroJuegos.puntajeJugador.ToString();
        audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        audio.Play();
    }
    public void PlayGame()
    {
        CentroJuegos.puntajeJugador = 0;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
}
