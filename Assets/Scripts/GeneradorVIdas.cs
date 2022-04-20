using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorVIdas : MonoBehaviour
{
    public GameObject _VidaPrefab;
    public GameObject _gameManager;    
    void Start()
    {
        InvokeRepeating("GenerarVida", 5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void GenerarVida()
    {   // vector derecho y izquierdo 
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        GameObject vida = Instantiate(_VidaPrefab);
        vida.transform.position = new Vector2(minPantalla.x ,Random.Range(minPantalla.y, maxPantalla.y));
    }
        public void DetenerGeneracion(){
        CancelInvoke("GenerarVida");
    }
}
