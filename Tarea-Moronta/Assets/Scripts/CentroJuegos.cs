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
    int mapaActual = 0;
    Disparar disparador;
    AudioSource audio;
    public TextMesh misPuntos;

    public GameObject[] mapas = new GameObject[3];
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
       misPuntos.text = puntajeJugador.ToString();
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
                    puntajeJugador += 1;
                    misPuntos.text = puntajeJugador.ToString();
                    //generarMapa();
                    nextenemy = Instantiate(enemy,new Vector3 (-3.871404f, 8.81884f),Quaternion.identity);
                    //nextenemy.transform.parent = GameObject.Find("Plataforma Foe").transform;
                    //nextenemy.transform.localPosition = new Vector3(0.382f, 1.14f);
                    //nextenemy.transform.position = new Vector3(mapas[mapaActual].transform.position.x, mapas[mapaActual].transform.position.y);
                    //nextenemy.transform.SetParent( GameObject.Find("Plataforma Foe").transform);
                    //nextenemy.transform.parent = null;
                    //personaje.transform.parent = null;
                    //personaje.transform.position = new Vector3(mapa1.transform.position.x - 11f, mapa1.transform.position.y + 3.08f);
                    //GameObject.Find("Main Camera").transform.position = new Vector3(mapas[mapaActual].transform.position.x , mapas[mapaActual].transform.position.y + 0.98948f, -10);
                    bananaAlive = true;
                    acertado = false;
                    turno = eTurno.TurnoJugador;
                    //mapaActual++;
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
    void generarMapa()
    {
        Destroy(GameObject.FindGameObjectWithTag("Respawn"));
        nextmap = Instantiate(mapas[mapaActual]);
        nextmap.SetActive(true);
        nextmap.transform.position = new Vector3(mapas[mapaActual].transform.position.x - 19.422f, mapas[mapaActual].transform.position.y + 4.08948f);
        mapas[mapaActual] = nextmap;
    }

}
