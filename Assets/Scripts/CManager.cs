using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CManager : MonoBehaviour
{
    public bool etapaDisjuntor = false;
    public bool etapaVitima = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isOrdemCorreta()
    {
        if(etapaDisjuntor == true && etapaVitima == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
