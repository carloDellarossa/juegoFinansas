using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;

public class Receta : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }


    public void cargarRecetas(string jsonArray)
    {
        JSONArray recetas = JSON.Parse(jsonArray) as JSONArray;
        string componentPath = "MisRecetas/Contenido/productoRecetaItem";

        for (int i = 0; i < recetas.Count; i++)
        {

            GameObject item = Instantiate(Resources.Load("productoRecetaItem") as GameObject);

            try
            {
                item.transform.SetParent(GameObject.Find("MisRecetas/Popup/Contenido/").transform);
                item.transform.localScale = Vector3.one;
                item.transform.localPosition = Vector3.zero;

                string nombre = recetas[i]["descripcion"];
                string id = recetas[i]["id"];

                Text uiNombre = item.transform.Find("nombre").GetComponent<Text>();
                Text uiId = item.transform.Find("id").GetComponent<Text>();

                uiNombre.text = nombre;
                uiId.text = id;


                for (int a = 0; a < recetas[i]["componentes"].Count; a++)
                {
                    GameObject item2 = Instantiate(Resources.Load("recetaItem") as GameObject);

                    item2.transform.SetParent(GameObject.Find("MisRecetas/Popup/Contenido/productoRecetaItem(Clone)/receta").transform);
                    item2.transform.localScale = Vector3.one;
                    item2.transform.localPosition = Vector3.zero;

                    string descripcion = recetas[i]["componentes"][a]["transable"]["descripcion"];
                    string cantidad = recetas[i]["componentes"][a]["cantidad"];

                    Text uiDescripcion = item2.transform.Find("nombre").GetComponent<Text>();
                    Text uiCantidad = item2.transform.Find("cantidad").GetComponent<Text>();

                    uiDescripcion.text = descripcion;
                    uiCantidad.text = cantidad;



                }

            }
            catch (NullReferenceException e)
            {
                Debug.Log(e);
            }

        }




    }
}
