using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    Grid grid;
    public Camera cam;
    public LineRenderer lineRender;

    public Animator blankTileUI;
    public Animator plotUI;
    public PotatoShop potatoShop;

    bool menuOut = false;
    bool blankUIout = false;
    bool plotUIout = false;

    int cellSize = 10;

    private void Awake()
    {
        grid = new Grid(20,20,10);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 clickPosition = hit.point;
                grid.highlightSquare(clickPosition);

                GameObject selectedPlane = hit.collider.gameObject;
                Grid.selectedPlane = selectedPlane;
                Debug.Log(Grid.selectedPlane.name);

                DrawLines(clickPosition, selectedPlane);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                PotatoPlot potatoPlot = hit.collider.gameObject.GetComponent<PotatoPlot>();
                if(potatoPlot != null)
                {
                    potatoPlot.Harvest();
                }
            }
        }
    }

    void DrawLines(Vector3 position, GameObject selectedPlane)
    {
        clearLines();
        lineRender.enabled = true;
        int x_cell = (int)(Mathf.Floor(position.x / cellSize) * cellSize);
        int y_cell = (int)(Mathf.Floor(position.z / cellSize) * cellSize);
        Vector3[] Vertices = new Vector3[4];
        Vertices[0] = new Vector3(x_cell, 0, y_cell);
        Vertices[1] = new Vector3(x_cell + cellSize, 0, y_cell);
        Vertices[2] = new Vector3(x_cell + cellSize, 0, y_cell + cellSize);
        Vertices[3] = new Vector3(x_cell, 0, y_cell + cellSize);
        lineRender.SetPositions(Vertices);

        tilledPlot farmPlot = selectedPlane.GetComponent<tilledPlot>();
        if(farmPlot != null)
        {
            plotUI.Play("slideIn");
            menuOut = true;
            plotUIout = true;
        }
        else if(Grid.selectedPlane.tag != "Barn")
        {
            blankTileUI.Play("slideIn");
            menuOut = true;
            blankUIout = true;
        }
    }

    public void clearLines()
    {
        lineRender.enabled = false;
        if(menuOut)
        {
            if (plotUIout)
            {
                plotUI.Play("slideOut");
            }
            if (blankTileUI)
            {
                blankTileUI.Play("slideOut");
            }

            menuOut = false;
            plotUIout = false;
            blankUIout = false;

        }
        if (potatoShop.shopOpen)
        {
            potatoShop.hideShop();
        }
    }

    public void harvestPotatos()
    {
        PotatoPlot potatoPlot = Grid.selectedPlane.GetComponent<PotatoPlot>();
        if(potatoPlot != null)
        {
            potatoPlot.Harvest();
        }
    }


}
