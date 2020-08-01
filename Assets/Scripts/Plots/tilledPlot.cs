using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilledPlot : MonoBehaviour
{
    AudioManager auMan;
    private void Start()
    {
        transform.position = new Vector3(Grid.selectedCell_x + 5, 0, Grid.selectedCell_y + 5);
        auMan = GameObject.FindObjectOfType<AudioManager>();
        auMan.Play("plant");
    }
}
