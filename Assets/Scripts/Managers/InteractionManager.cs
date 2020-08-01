using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    public GameObject tilledLandpreFab;
    public GameObject blankLandPrefab;
    Transform tilePos;
    MoneyManger moneyManger;
    GridManager gridManager;

    private void Awake()
    {
        gridManager = GameObject.FindObjectOfType<GridManager>();
        moneyManger = GameObject.FindObjectOfType<MoneyManger>();
        tilePos = transform;
    }

    public void TillLand()
    {
        if(moneyManger.taters >= 200)
        {
            tilePos.position = new Vector3(Grid.selectedCell_x + 5, 0, Grid.selectedCell_y + 5);
            Destroy(Grid.selectedPlane);
            Instantiate(tilledLandpreFab);
            moneyManger.changeFunds(-200);
            gridManager.clearLines();
        }
        
    }

    public void plantPotato(GameObject potatoPlotPrefab)
    {
        float cost = potatoPlotPrefab.GetComponent<PotatoPlot>().cost;
        if (moneyManger.taters >= cost)
        {
            moneyManger.changeFunds(-cost);
            Destroy(Grid.selectedPlane);
            Instantiate(potatoPlotPrefab);
        }
    }

    public void destroyPlot()
    {
        Destroy(Grid.selectedPlane);
        Instantiate(blankLandPrefab);
        gridManager.clearLines();
    }
}
