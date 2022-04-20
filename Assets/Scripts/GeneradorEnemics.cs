  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemics : MonoBehaviour
{
    public GameObject _EnemgoPrefab;
    
    public GameObject _EnemgoPrefab2;
    public GameObject _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Invoke ("GenerarEnemigo", 5);
        InvokeRepeating("GenerarEnemigo", 2, 3);
        InvokeRepeating("GenerarEnemigo2", 5, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DetenerGeneracion(){
        CancelInvoke("GenerarEnemigo");
    }

    public void GenerarEnemigo()
    {   // vector derecho y izquierdo 
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //generar enemigo en posicion aleatoria
        GameObject enemigo = Instantiate(_EnemgoPrefab);
        enemigo.transform.position = new Vector2(
            Random.Range(minPantalla.x, maxPantalla.x),
            maxPantalla.x
        );
    }
        public void GenerarEnemigo2()
    {   // vector derecho y izquierdo 
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //generar enemigo en posicion aleatoria
        GameObject enemigo = Instantiate(_EnemgoPrefab2);
        enemigo.transform.position = new Vector2(
            Random.Range(minPantalla.x, maxPantalla.x),
            maxPantalla.x
        );
    }
}
