using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    public float _velPunto = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos = new Vector2(pos.x, pos.y - _velPunto * Time.deltaTime);
        transform.position = pos;

        Vector2 limitInferior = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < limitInferior.y)
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
