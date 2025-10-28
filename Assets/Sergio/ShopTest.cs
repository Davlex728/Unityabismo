using UnityEngine;
using TMPro;

public class ShopTest : MonoBehaviour
{
    public TMP_Text textoPantalla;
    public int dinero = 200;
    public int precioTorre = 100;

    void Start()
    {
        textoPantalla.text = "Dinero: " + dinero;
    }

    void OnMouseDown()
    {
        if (dinero >= precioTorre)
        {
            dinero -= precioTorre;
            textoPantalla.text = "Compraste una torre. Dinero: " + dinero;
            Debug.Log("Torre comprada con éxito");
        }
        else
        {
            textoPantalla.text = "No tienes suficiente dinero";
            Debug.Log("No puedes, no tienes el dinero suficiente");
        }
    }
}
