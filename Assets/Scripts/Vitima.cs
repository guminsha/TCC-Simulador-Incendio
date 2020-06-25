using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitima : MonoBehaviour
{
    private CManager scriptCManager;
    // Start is called before the first frame update
    void Start()
    {
        scriptCManager = FindObjectOfType<CManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GrabVolumeBig" || other.name == "GrabVolumeSmall")
        {
            if (scriptCManager.etapaDisjuntor == true)
            {
                scriptCManager.etapaVitima = true;
                Destroy(gameObject);
            }
        }
    }
}
