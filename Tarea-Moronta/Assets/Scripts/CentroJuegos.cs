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
    float MaxCooldown = 50f;
    float Cooldown = 0f;
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
    GameObject actualMap;
    bool mapGen = false;
    int mapGenNum = 0;
    bool plataforma = true;
    public GameObject personaje;
    public GameObject enemy;

    GameObject nextenemy;
    Vector3 vectorGM;
    Vector3 vectorDP1;
    Vector3 vectorDP2;
    Vector3 vectorMC;
    Vector3 vectorNM;
    int pasos = 0;

    // Start is called before the first frame update
    void Start()
    {
       turno = eTurno.GenerandoMap;
       audio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
       audio.Play();
       misPuntos.text = puntajeJugador.ToString();
       vectorGM = new Vector3(0.12f, GameObject.Find("Mapa 1").transform.position.y, 3);
       vectorDP1 = new Vector3(1.48f, -0.9183253f);
        vectorDP2 = new Vector3(8f,0);
        
        vectorMC = new Vector3(0, 1.05f,-10f);

       
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
                        actualMap = Instantiate(mapaInv);
                        actualMap.transform.position = vectorGM;
                        enemy = actualMap.transform.GetChild(3).gameObject;
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
                    //plataforma = !plataforma;
                    turno = eTurno.Caminando;

                }
                break;
            /*case eTurno.Caminando:
                
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
                    
                }
                else
                {
                    pasos = 0;
                    turno = eTurno.TurnoJugador;
                }
                break;*/
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

    private void FixedUpdate()
    {
        if(Cooldown > 0)
        {
            Cooldown--;
        }
        switch (turno)
        {
            case eTurno.Caminando:

                if (pasos <= 1 && Cooldown <= 0)
                {
                    Cooldown = MaxCooldown;
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
                    //StartCoroutine(Example());

                }
                else if(pasos == 2)
                {
                    if (plataforma)
                    {
                        personaje.transform.Rotate(0f, 180f, 0f);
                    }
                    else if (!plataforma)
                    {
                        personaje.transform.Rotate(0f, 0f, 0f);
                    }
                    pasos = 0;
                  
                    vectorMC.y += 3f;
                    GameObject.Find("Main Camera").transform.position = vectorMC;

                    actualMap.transform.position = new Vector3(actualMap.transform.position.x, actualMap.transform.position.y, 0f);
                    enemy = actualMap.transform.GetChild(3).gameObject;
                    enemy.SetActive(true);
                    actualMap = nextMap;
                    nextMap = null;
                    vectorGM.y += 4.04f;
                    if (mapGen)
                    {
                        //Vector3 mivector = new Vector3(0.12f, nextMap.transform.position.y + 4.04f, 3);
                        nextMap = Instantiate(mapaNorm);
                        nextMap.transform.position = vectorGM; //new Vector3(0.12f, GameObject.Find("Mapa 1").transform.position.y + 4.04f, 3);
                        enemy = nextMap.transform.GetChild(3).gameObject;
                        enemy.SetActive(false);
                        //mapGen = false;
                    }
                    
                    if (!mapGen)
                    {
                        nextMap = Instantiate(mapaInv);
                        nextMap.transform.position = vectorGM;
                        enemy = nextMap.transform.GetChild(3).gameObject;
                        enemy.SetActive(false);
                        //mapGen = true;
                    }
                    mapGen = !mapGen;
                    turno = eTurno.TurnoJugador;
                }
                //StartCoroutine(Example());
                //turno = eTurno.TurnoJugador;
                break;
        }
    }
   /* IEnumerator Example()
    {
        if (pasos <= 1 && Cooldown<=0f)
        {
            Cooldown = MaxCooldown;
            if (pasos == 0)
            {
                vectorDP1.x *= -1;
                vectorDP1.y += 1.15f;
                personaje.transform.position = vectorDP1;
                //yield return new WaitForSeconds(2);
            }

            if (pasos == 1)
            {
                vectorDP2.x *= -1;
                vectorDP2.y += 2.8f;
                personaje.transform.position = vectorDP2;
                //yield return new WaitForSeconds(2);
            }

            pasos++;
            //StartCoroutine(Example());

        }
        else
        {
            pasos = 0;
            turno = eTurno.TurnoJugador;
        }
        print(Time.time);
        yield return new WaitForSeconds(10);
        print(Time.time);
    }*/

}
