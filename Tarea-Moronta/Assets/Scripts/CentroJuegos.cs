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
    }
    public eTurno turno { get; set; }
    public bool acertado = false;
    int puntajeJugador = 0;
    Disparar disparador;
    
    // Start is called before the first frame update
    void Start()
    {
       turno = eTurno.TurnoJugador;
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
                    disparador.dispararBanana();
                    turno = eTurno.Comprobando;

                }

                break;
            case eTurno.Comprobando:

                if (!acertado)
                {
                    turno = eTurno.TurnoMaquina;
                }
                else
                {
                    puntajeJugador++;
                }
                break;
            case eTurno.TurnoMaquina:




                break;
         
        }

     
        
    }

}
