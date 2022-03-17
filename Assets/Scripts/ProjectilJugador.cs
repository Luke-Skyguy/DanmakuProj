using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilJugador : MonoBehaviour
{
    public float _velProyectil= 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 posicioProjectil= transform.position;
        posicioProjectil=new Vector2(posicioProjectil.x,posicioProjectil.y+_velProyectil*Time.deltaTime);
        transform.position=posicioProjectil;

        Vector2 maxPantalla= Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.y> maxPantalla.y){
            Destroy(gameObject);
        }

    }
}
