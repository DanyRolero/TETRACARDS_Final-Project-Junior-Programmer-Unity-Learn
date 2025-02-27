using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Añadir a un gameobject con hijos que se quieran distribuir uniformemente en el eje x.
public class HorizontalUniformDistributor : MonoBehaviour
{
    public float gap;
    public Alignment alignment = Alignment.CENTER;
    public Rect rectArea;
    private Rect subrectArea;
    public GameObject container;
    public GameObject item;
    private List<Vector3> itemsPositions;

    //--------------------------------------------------------------------------------
    void Start()
    {
        container = this.gameObject;
    }


    //--------------------------------------------------------------------------------
    public void UpdateDistributor()
    {
        if (container.transform.childCount == 0) return;
        UpdateSubrect();
        UpdateListPositions();
        UpdateItemsPositions();
    }


    //--------------------------------------------------------------------------------
    private void UpdateSubrect()
    {
        this.subrectArea = new Rect();
        this.subrectArea.y = rectArea.y;
        this.subrectArea.height = rectArea.height;

        this.subrectArea.width = CalculateWidthSubrectArea();
        this.subrectArea.x = CalculateXSubrectArea();
    }


    //--------------------------------------------------------------------------------
    private void UpdateListPositions()
    {
        float currentXPosition = subrectArea.x + item.GetComponent<Transform>().localScale.x / 2 + gap;
        int amountItems = container.transform.childCount;
        float widthOfItem = item.GetComponent<Transform>().localScale.x;

        itemsPositions = new List<Vector3>();

        if (subrectArea.width < rectArea.width)
        {
            for (int i = 0; i < amountItems; i++)
            {
                itemsPositions.Add(new Vector3(currentXPosition, rectArea.y, 0));
                currentXPosition += widthOfItem + gap * 2;
            }
            return;
        }

        currentXPosition = subrectArea.x + widthOfItem / 2;
        float totalWidthPositionable = subrectArea.width - widthOfItem;
        float distanceBetweenItems = totalWidthPositionable / (amountItems - 1);
        for (int i = 0; i < amountItems; i++)
        {
            itemsPositions.Add(new Vector3(currentXPosition, rectArea.y, 0));
            currentXPosition += distanceBetweenItems;
        }
    }


    //--------------------------------------------------------------------------------
    private float CalculateWidthSubrectArea()
    {
        float widthOfItem = item.GetComponent<Transform>().localScale.x;
        int amountItems = container.transform.childCount;
        float totalGapWidth = gap * amountItems * 2;
        float totalWidth = widthOfItem * amountItems + totalGapWidth;

        if (totalWidth > rectArea.width) return rectArea.width;
        return totalWidth;
    }


    //--------------------------------------------------------------------------------
    private float CalculateXSubrectArea()
    {
        if (subrectArea.width == rectArea.width) return rectArea.x;

        float xStart = 0;

        switch (alignment)
        {
            case Alignment.LEFT:
                xStart = rectArea.x;
                break;
            case Alignment.CENTER:
                xStart = rectArea.x + (rectArea.width - subrectArea.width) / 2;
                break;
            case Alignment.RIGHT:
                xStart = rectArea.x + rectArea.width - subrectArea.width;
                break;
        }
        return xStart;
    }


    //--------------------------------------------------------------------------------
    private void UpdateItemsPositions()
    {
        for (int i = 0; i < container.transform.childCount; i++)
        {
            container.transform.GetChild(i).transform.localPosition = itemsPositions[i];
        }
    }
}