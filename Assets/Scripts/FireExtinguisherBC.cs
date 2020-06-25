using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherBC : MonoBehaviour
{
    public GameObject cubo;
    public GameObject msg;
    public GameObject msg2;
    private bool audiobool = true;
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

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Fire Class B")
        {
            Fogo ScriptFogo = other.GetComponent<Fogo>();
            StartCoroutine(ScriptFogo.diminuirFogo());
        }
        else if (other.tag == "Fire Class C")
        {
            if(scriptCManager.isOrdemCorreta() == true)
            {
                other.GetComponent<ParticleSystem>().Stop();
                if (cubo && audiobool)
                {
                    cubo.GetComponent<AudioSource>().Play();
                    audiobool = false;
                }
            }
            else if(scriptCManager.isOrdemCorreta() == false)
            {
                msg2.SetActive(true);
                StartCoroutine("Incorreto2");
            }
        }
        else if (other.tag == "Fire Class A" || other.tag == "Fire Class D" || other.tag == "Fire Class K")
        {
            msg.SetActive(true);
            StartCoroutine("Incorreto");
        }
    }

    IEnumerator Incorreto()
    {
        yield return new WaitForSeconds(3f);
        msg.SetActive(false);
    }

    IEnumerator Incorreto2()
    {
        yield return new WaitForSeconds(3f);
        msg2.SetActive(false);
    }

}




