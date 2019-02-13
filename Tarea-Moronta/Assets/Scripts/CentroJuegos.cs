using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CentroJuegos : MonoBehaviour
{
   public enum eTurno
    {
        GenerandoMap,
        TurnoJugador,
        Comprobando,
        Caminando,
        TurnoMaquina,
        Fin
    }
    float zhenpeng = 100f;
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

    public GameObject mapaNorm;
    public GameObject mapaInv;
    GameObject nextMap;
    bool mapGen = false;
    int mapGenNum = 0;
    bool plataforma = true;
    public GameObject personaje;
    public GameObject enemy;

    GameObject nextenemy;
    Vector3 vectorGM;
    Vector3 vectorDP1;
    Vector3 vectorDP2;
    int pasos = 0;

    // Start is called before the first frame update
    void Start()
    {
       turno = eTurno.GenerandoMap;
       audio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
       audio.Play();
       misPuntos.text = puntajeJugador.ToString();
       vectorGM = new Vector3(0.12f, GameObject.Find("Mapa 1").transform.position.y, 3);
       vectorDP1 = new Vector3(1.48f,0);
        vectorDP2 = new Vector3(8f,0);
       
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (turno)
        {
            case eTurno.GenerandoMap:
                if (mapGenNum <= 1)
                {
                    vectorGM.y += 4.04f;
                    if (!mapGen)
                    {
                        nextMap = Instantiate(mapaInv);
                        nextMap.transform.position = vectorGM;
                        enemy = nextMap.transform.GetChild(3).gameObject;
                        enemy.SetActive(false);
                        //mapGen = true;
                    }

                    if (mapGen)
                    {
                        //Vector3 mivector = new Vector3(0.12f, nextMap.transform.position.y + 4.04f, 3);
                        nextMap = Instantiate(mapaNorm);
                        nextMap.transform.position = vectorGM; //new Vector3(0.12f, GameObject.Find("Mapa 1").transform.position.y + 4.04f, 3);
                        enemy = nextMap.transform.GetChild(3).gameObject;
                        enemy.SetActive(false);
                        //mapGen = false;
                    }
                    mapGen = !mapGen;
                    mapGenNum++;
                }
                else
                {
                    mapGenNum = 0;
                    turno = eTurno.TurnoJugador;
                }
                break;
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
                    //nextenemy = Instantiate(enemy,new Vector3 (-3.871404f, 8.81884f),Quaternion.identity);
                    bananaAlive = true;
                    acertado = false;
                    plataforma = !plataforma;
                    turno = eTurno.Caminando;

                }
                break;
            case eTurno.Caminando:
                
                if (pasos <= 1)
                {
                    if (pasos == 0)
                    {
                        vectorDP1.x *= -1;
                        vectorDP1.y += 1.15f;
                        personaje.transform.position = vectorDP1;
                    }

                    if (pasos == 1)
                    {
                        vectorDP2.x *= -1;
                        vectorDP2.y += 2.8f;
                        personaje.transform.position = vectorDP2;
                    }

                    pasos++;
                    //yield return new WaitForSeconds(5);
                }
                else
                {
                    pasos = 0;
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

    void FixedUpdate()
    {
        
        
    }

}
