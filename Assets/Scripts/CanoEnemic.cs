using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoEnemic : MonoBehaviour
{
public GameObject _projectilEnemicPrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void DispararProjectil(){
         GameObject nauJugador = GameObject.Find("Nau1");

         if (nauJugador!=null){
             
             GameObject projectil= Instantiate(_projectilEnemicPrefab);

             projectil.transform.position= transform.position;

             Vector2 direccioProjectil=
             nauJugador.transform.position - projectil.transform.position;
             projectil.GetComponent<ProjectilEnemigo>().setDireccio(direccioProjectil);
         }
    }
}
