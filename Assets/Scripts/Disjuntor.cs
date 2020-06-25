using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disjuntor : MonoBehaviour
{
    private CManager scriptCManager;
    public GameObject luz1;
    public GameObject luz2;
    public GameObject luz3;
    public GameObject luz4;

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
        if(other.name == "GrabVolumeBig" || other.name == "GrabVolumeSmall")
        {
            scriptCManager.etapaDisjuntor = true;
            luz1.GetComponent<MeshRenderer>().material.color = Color.red;
            luz2.GetComponent<MeshRenderer>().material.color = Color.red;
            luz3.GetComponent<MeshRenderer>().material.color = Color.red;
            luz4.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
