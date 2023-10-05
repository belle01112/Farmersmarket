using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VeggieCounter : MonoBehaviour
{
    public static VeggieCounter instance;
    public TextMeshProUGUI veggieText;
    public int currentVeggies = 0;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(veggieText.text);
        veggieText.text = "VEGGIES: " + currentVeggies;
    }

    public void IncreaseVeggies(int v)
    {
        currentVeggies += v;
        veggieText.text = "VEGGIES: " + currentVeggies.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
