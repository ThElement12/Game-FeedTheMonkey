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
  /*  public GameObject fondo1;
    public GameObject fondo2;
    public GameObject fondo3;*/


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
                disparador = GameObject.Find("Disparador").GetComponent<Disparar>();
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
                {
                   
                    disparador.dispararBanana();
                   
                }

                break;
            case eTurno.Comprobando:

                if (!acertado && !bananaAlive)
                {
                    turno = eTurno.TurnoMaquina;
                }
                else
                {
                    puntajeJugador ++;
                    misPuntos.text = puntajeJugador.ToString();
                    nextenemy = Instantiate(enemy,new Vector3 (-3.871404f, 8.81884f),Quaternion.identity);
                    bananaAlive = true;
                    acertado = false;
                    turno = eTurno.TurnoJugador;

                }
                break;
            case eTurno.TurnoMaquina:

                disparador = GameObject.FindGameObjectWithTag("Foe").GetComponent<Disparar>();
                disparador.dispararPoop();

                break;
            case eTurno.Fin:

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                break;
         
        }

     
        
    }

}
