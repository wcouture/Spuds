using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blankLand : MonoBehaviour
{
    private void Awake()
    {
        transform.position = new Vector3(Grid.selectedCell_x + 5, 0, Grid.selectedCell_y + 5);
    }
}
