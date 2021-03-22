using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;

public class Canje : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }


    public void cargarCanjes(string jsonArray)
    {
        JSONArray canjes = JSON.Parse(jsonArray) as JSONArray;
        string componentPath = "Canje/Contenido/canjeItem";

        for (int i = 0; i < canjes.Count; i++)
        {

            GameObject item = Instantiate(Resources.Load("canjeItem") as GameObject);
            try
            {
                item.transform.SetParent(GameObject.Find("Canje/Popup/Contenido").transform);
                item.transform.localScale = Vector3.one;
                item.transform.localPosition = Vector3.zero;

                string itemText = canjes[i]["tipo"] + " " + canjes[i]["cantidad"];
                string costo = canjes[i]["puntos"] + " Puntos";
                string id = canjes[i]["id"];
                string cantidad = canjes[i]["cantidad"];

                Text uiId = item.transform.Find("id").GetComponent<Text>();
                Text uiItem = item.transform.Find("Item").GetComponent<Text>();
                Text uiCosto = item.transform.Find("Button/Costo").GetComponent<Text>();
                Text uiCantidad = item.transform.Find("cantidad").GetComponent<Text>();

                uiId.text = id;
                uiItem.text = itemText;
                uiCosto.text = costo;
                uiCantidad.text = cantidad;
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e);
            }




        }

    }
}
