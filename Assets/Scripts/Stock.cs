using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;

public class Stock : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }


    public void cargarStock(string jsonArray)
    {
        JSONArray stock = JSON.Parse(jsonArray) as JSONArray;
        string componentPath = "MisProductos/Contenido/productoItem";

        for (int i = 0; i < stock.Count; i++)
        {

            GameObject item = Instantiate(Resources.Load("productoItem") as GameObject);
            try
            {

                item.transform.SetParent(GameObject.Find("MisProductos/Popup/Contenido").transform);
                item.transform.localScale = Vector3.one;
                item.transform.localPosition = Vector3.zero;

                //armar cabezera
                string id = stock[i]["producto"]["id"];
                string Nombre = stock[i]["producto"]["nombre"];
                string Descripcion = stock[i]["producto"]["descripcion"];
                string Stock = stock[i]["cantidad"];
                string Unidad = stock[i]["uni_med"]["nombre"];

                Text uiId = item.transform.Find("id").GetComponent<Text>();
                Text uiNombre = item.transform.Find("nombre").GetComponent<Text>();
                Text uiDescripcion = item.transform.Find("descripcion").GetComponent<Text>();
                Text uiUnidad = item.transform.Find("unidad").GetComponent<Text>();
                Text uiStock = item.transform.Find("stock").GetComponent<Text>();

                uiId.text = id;
                uiNombre.text = Nombre;
                uiDescripcion.text = Descripcion;
                uiUnidad.text = Unidad;
                uiStock.text = Stock;

            }
            catch (NullReferenceException e)
            {
                Debug.Log(e);
            }




        }

    }
}