using UnityEngine;

public class Cuadricula : MonoBehaviour
{
    public GameObject CellPrefab;
    public int ancho = 6;
    public int alto = 5;
    public float espacio = 2.0f;

    void Start()
    {
        GenerarGrid();
    }

    void GenerarGrid()
    {
        float centrox = (ancho - 1) * espacio / 2f;
        float centroy = (alto - 1) * espacio / 2f;

        // bucle para generar las celdas
        for (int i = 0; i < ancho; i++)
        {
            for (int j = 0; j < alto; j++)
            {
                Vector2 posicion = new Vector2(i * espacio - centrox, j * espacio - centroy);
                GameObject cell = Instantiate(CellPrefab, posicion, Quaternion.identity);
                cell.transform.parent = this.transform;
            }
        }
    }
}