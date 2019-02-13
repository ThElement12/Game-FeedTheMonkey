using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CentroJuegos : MonoBehaviour
{
   public enum eTurno
    {
        
        TurnoJugador,
        Comprobando,
        TurnoMaquina,
        Fin
    }
    public static eTurno turno; //{ get; set; }
    public bool acertado = false;
    public bool bananaAlive = true;
    public static int puntajeJugador = 0;
    int mapaActual = 0;
    Disparar disparador;
    AudioSource audio;
    public TextMesh misPuntos;


    public GameObject personaje;
    public GameObject enemy;

    GameObject nextenemy;
 

    // Start is called before the first frame update
    void Start()
    {
       turno = eTurno.TurnoJugador;
       audio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
       audio.Play();
       misPuntos.text = puntajeJugador.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (turno)
        {
            case eTurno.TurnoJugador:
                ///Si es turno del jugador pues comienza a disparar
                disparador = GameObject.Find("Disparador").GetComponent<Disparar>();
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
                {
                   
                    disparador.dispararBanana();
                   
                }

                break;
            case eTurno.Comprobando:
                ///Aqui comprueba si el usuario acerto o no
                if (!acertado && !bananaAlive)
                {
                    turno = eTurno.TurnoMaquina;
                }
                else
                {
                    //Aqui se inicializa el siguiente nivel 
                    puntajeJugador ++;
                    misPuntos.text = puntajeJugador.ToString();
                    nextenemy = Instantiate(enemy,new Vector3 (-3.871404f, 8.81884f),Quaternion.identity);
                    bananaAlive = true;
                    acertado = false;
                    turno = eTurno.TurnoJugador;

                }
                break;
            case eTurno.TurnoMaquina:
                ///Aqui la maquina le dispara 

                disparador = GameObject.FindGameObjectWithTag("Foe").GetComponent<Disparar>();
                disparador.dispararPoop();

                break;
            case eTurno.Fin:
                ///CAmbio de escena

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                break;
         
        }

     
        
    }

}
