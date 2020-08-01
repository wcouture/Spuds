using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoPlot : tilledPlot
{
    public float growTime = 100f;
    public float yieldMax = 30;
    public float yieldMin = 10;
    public float cost = 0;
    float progress = 0;
    bool grown = false;
    MoneyManger moneyManager;

    AudioManager audMan;

    public ParticleSystem growCompleteEffect;
    public Animator growAnimation;

    private void Awake()
    {
        audMan = AudioManager.instance;
        transform.position = new Vector3(Grid.selectedCell_x + 5, 0, Grid.selectedCell_y + 5);
        growAnimation.speed = (1 / growTime);
        moneyManager = GameObject.FindObjectOfType<MoneyManger>();
        StartCoroutine("growPotatoes");
    }

    public void Harvest()
    {
        if (grown)
        {
            audMan.Play("harvest");
            Debug.Log("Harvest Initiated");
            float tatersEarned = Random.Range(yieldMin, yieldMax);
            moneyManager.changeFunds(tatersEarned);
            grown = false;
            progress = 0;
            growAnimation.Play("potatoBegin");
            StartCoroutine("growPotatoes");
        }
    }

    IEnumerator growPotatoes()
    {
        growAnimation.SetTrigger("playGrowAnim");
        while(progress < growTime)
        {
            progress++;
            yield return new WaitForSeconds(1);
        }
        grown = true;
        audMan.Play("grow");
        growCompleteEffect.Play();
    }
}
