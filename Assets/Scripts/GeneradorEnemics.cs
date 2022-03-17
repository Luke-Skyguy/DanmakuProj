using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemics : MonoBehaviour
{
    public GameObject _EnemgoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Invoke ("GenerarEnemigo", 5);
        InvokeRepeating("GenerarEnemigo", 5, 3);
    }

    // Update is called once per frame
    void Update()
    {

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
}
