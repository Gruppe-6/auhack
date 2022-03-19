using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoneyGrid : MonoBehaviour
{
    [SerializeField] private string[] Headers =
        {"Bolig", "Mad", "Transport", "Øvrige faste", "Diverse", "Gældsafvikling", "Misligholdt gæld"};

    [SerializeField] private float spacing = 0.18f;
    [SerializeField] private float verticalOffset = 0.05f;
    [SerializeField] private int initialSpace;

    private List<List<Vector3>> grid = new List<List<Vector3>>();

    
    private int Cols => Headers.Length;

    private void Awake()
    {
        foreach (var header in Headers)
        {
            grid.Add(new List<Vector3>());
        }
    }

    public Vector3 Next(int column)
    {
        Vector3 v = Offset(column, grid[column].Count);
        grid[column].Add(v);
        return v;
    }

    private Vector3 Offset(int hPlace, int vPlace) => transform.position + transform.forward * (verticalOffset * vPlace)
                                                                         + -transform.right * (spacing * hPlace);
}
