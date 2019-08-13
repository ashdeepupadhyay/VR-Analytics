using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GazeButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public float gazeTime = 2f;
    private float timer = 0f;
    private bool gazedAt = false;
    public int funcno;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gazedAt)
        {
            timer += Time.deltaTime;
            if (timer >= gazeTime)
            {
                CheckFunc(funcno);
                timer = 0f;
            }
        }
    }

    void CheckFunc(int funcno)
    {
        if (funcno == 0)
        {
            Window_Graph.instance.SetGraphVisual("barGraphVisual");
        }
        else if (funcno == 1)
        {
            Window_Graph.instance.SetGraphVisual("lineGraphVisual");
        }
        else if(funcno==2)
        {
            Window_Graph.instance.IncreaseGraphVisual();
        }
        else if(funcno==3)
        {
            Window_Graph.instance.DecreaseGraphVisual();
        }
        else if(funcno==4)
        {
            Window_Graph.instance.SetGetAxisLabelY((float _f) => "$" + Mathf.RoundToInt(_f));
        }
        else
        {
            Window_Graph.instance.SetGetAxisLabelY((float _f) => "€" + Mathf.RoundToInt(_f / 1.18f));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gazedAt = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("gazedat");
        gazedAt = true;
    }
}

