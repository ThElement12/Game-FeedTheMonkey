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
    public static eTurno turno; //{ get; set; }
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
    GameObject nextenemy;
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
                    //turno = eTurno.Comprobando;


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
                    nextenemy = Instantiate(enemy);
                    nextenemy.transform.position = new Vector3(mapa1.transform.position.x - 23.422f, mapa1.transform.position.y + 6.03f);
                    mapa1 = nextmap;
                    //personaje.transform.parent = null;
                    //personaje.transform.position = new Vector3(mapa1.transform.position.x - 11f, mapa1.transform.position.y + 3.08f);
                    GameObject.Find("Main Camera").transform.position = new Vector3(mapa1.transform.position.x , mapa1.transform.position.y + 0.98948f, -10);
                    bananaAlive = true;
                    acertado = false;
                    turno = eTurno.TurnoJugador;
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
