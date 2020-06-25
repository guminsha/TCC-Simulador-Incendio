using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarExtintor : MonoBehaviour
{
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;
    public ParticleSystem fumaca;
    private AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController()))
        {
            fumaca.Play(true);
            sfx.Play();
        }
        else if(!ovrGrabbable.isGrabbed || OVRInput.GetUp(shootingButton, ovrGrabbable.grabbedBy.GetController()))
        {
            fumaca.Stop(true);
            sfx.Stop();
        }
    }
}
