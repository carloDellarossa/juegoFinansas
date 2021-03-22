using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;

public class Transable : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }


    public void cargarTransables(string jsonArray)
    {
        Debug.Log(jsonArray);

        JSONArray transables = JSON.Parse(jsonArray) as JSONArray;
        Debug.Log(transables);

        string componentPath = "Comprar/Contenido/productoCompraItem";

        for (int i = 0; i < transables.Count; i++)
        {

            GameObject item = Instantiate(Resources.Load("productoCompraItem") as GameObject);
            try
            {
          
                    item.transform.SetParent(GameObject.Find("Comprar/Popup/Contenido").transform);
                    item.transform.localScale = Vector3.one;
                    item.transform.localPosition = Vector3.zero;

                    string id = transables[i]["stock"]["producto"]["id"];
                    string proveedor = transables[i]["actor_id"] ;
                    string unidad = transables[i]["stock"]["umedida"];
                    string nombre = transables[i]["stock"]["producto"]["nombre"];

                    string precio = transables[i]["precio"];
                    string cta = "Stock proveedor : " + transables[i]["cantidad_ofertada"];
                    // string precio = transables[i]["precio"];

                    Text uiId = item.transform.Find("id").GetComponent<Text>();
                    Text uiProveedor = item.transform.Find("proveedor").GetComponent<Text>();
                    Text uiUnidad = item.transform.Find("unidad").GetComponent<Text>();
                    Text uiNombre = item.transform.Find("nombre").GetComponent<Text>();
                    Text uiPrecio = item.transform.Find("precio").GetComponent<Text>();
                    Text uiCta = item.transform.Find("cta").GetComponent<Text>();

                    // Text uiprecio = item.transform.Find("btn/precio").GetComponent<Text>();

                    uiId.text = id;
                    uiProveedor.text = proveedor;
                    uiUnidad.text = unidad;
                    uiNombre.text = nombre;
                    uiPrecio.text = precio;
                    uiCta.text = cta;


                


            }
            catch (NullReferenceException e)
            {
                Debug.Log(e);
            }




        }

    }
}