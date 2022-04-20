using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    public float _velVida = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 posicioVida = transform.position;
        posicioVida = new Vector2(posicioVida.x + _velVida * Time.deltaTime ,transform.position.y);
        transform.position = posicioVida;

        Vector2 limitInferior = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.x < limitInferior.x)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NauJugador")
        {
            Destroy(gameObject);
        }
    }
}
