using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public enum EstadosJuego
    {
        Inicio, Jugando, Resultados
    }

    public EstadosJuego _estatJuego;
    public GameObject _botonInicio;
    public GameObject _vidasNau;
    public GameObject _textInicio;
    public GameObject _textGameOver;
    public GameObject _nauJugador;
    public GameObject _generadorEnemics;
    // Start is called before the first frame update
    void Start()
    {
        _estatJuego = EstadosJuego.Inicio;
        ActualizarEstado();
    }
    private void ActualizarEstado()
    {
        switch (_estatJuego)
        {
            case EstadosJuego.Inicio:
                _vidasNau.SetActive(false);
                _textGameOver.SetActive(false);
                _generadorEnemics.SetActive(false);
                _nauJugador.SetActive(false);

                _textInicio.SetActive(true);
                _botonInicio.SetActive(true);
                break;
            case EstadosJuego.Jugando:
                _vidasNau.SetActive(true);
                _textGameOver.SetActive(false);
                _generadorEnemics.SetActive(true);
                _nauJugador.SetActive(true);
                _nauJugador.GetComponent<Nave>().reiniciarVidas();

                _textInicio.SetActive(false);
                _botonInicio.SetActive(false);

                break;
            case EstadosJuego.Resultados:
                _vidasNau.SetActive(false);
                _textGameOver.SetActive(true);

                _generadorEnemics.GetComponent<GeneradorEnemics>().DetenerGeneracion();
                _nauJugador.SetActive(false);

                _textInicio.SetActive(false);
                _botonInicio.SetActive(true);
                break;
        }
    }
    public void SetEstadoJugando()
    {
        _estatJuego = EstadosJuego.Jugando;
        ActualizarEstado();
    }

    public void SetEstadoGameOver()
    {
        _estatJuego = EstadosJuego.Resultados;
        ActualizarEstado();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
