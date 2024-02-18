using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public TextMeshProUGUI hpText; 
    public int hp = 100; 

    void Start()
    {
        hpText.text = hp.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (hpText != null)
        {
            hpText.text = hp.ToString(); 
        }
    }

    public void TakeDamage()
    {
    	hp -= 50;
    	hpText.text = hp.ToString();
    	if(hp <= 0)
    	{
    		Destroy(gameObject);
    	}
    }
}
