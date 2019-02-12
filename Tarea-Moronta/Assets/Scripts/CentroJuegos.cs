using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentroJuegos : MonoBehaviour
{
   public enum eTurno
    {
        
        TurnoJugador,
        Comprobando,
        TurnoMaquina,
        Fin
    }
    public eTurno turno { get; set; }
    public bool acertado = false;
    public bool bananaAlive = true;
    int puntajeJugador = 0;
    Disparar disparador;
    AudioSource audio;
    
    public GameObject mapa1;
    public GameObject mapa2;
    public GameObject mapa3;
    public GameObject personaje;
    public GameObject enemy;
    GameObject nextmap;

    // Start is called before the first frame update
    void Start()
    {
       turno = eTurno.TurnoJugador;
       audio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
       audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (turno)
        {
            case eTurno.TurnoJugador:
                disparador = GameObject.Find("Disparador").GetComponent<Disparar>();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                   // GameObject.FindGameObjectWithTag("Foe").transform.parent = null;
                    disparador.dispararBanana();
                    turno = eTurno.Comprobando;


                }

                break;
            case eTurno.Comprobando:

                if (!acertado && !bananaAlive)
                {
                    turno = eTurno.TurnoMaquina;
                }
                else
                {
                    puntajeJugador++;
                    nextmap = Instantiate(mapa1);
                    nextmap.SetActive(true);
                    nextmap.transform.position = new Vector3(mapa1.transform.position.x - 19.422f, mapa1.transform.position.y + 4.08948f);
                    turno = eTurno.TurnoJugador;
                    mapa1 = nextmap;
                }
                break;
            case eTurno.TurnoMaquina:

                disparador = GameObject.FindGameObjectWithTag("Foe").GetComponent<Disparar>();
                disparador.dispararPoop();
                turno = eTurno.Fin;

                break;
            case eTurno.Fin:

                

                break;
         
        }

     
        
    }

}
