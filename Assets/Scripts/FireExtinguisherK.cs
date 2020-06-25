using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherK : MonoBehaviour
{
    public GameObject msg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Fire Class A")
        {
            Fogo ScriptFogo = other.GetComponent<Fogo>();
            StartCoroutine(ScriptFogo.diminuirFogo());
        }
        else if (other.tag == "Fire Class K")
        {
            other.GetComponent<ParticleSystem>().Stop();
        }
        else if (other.tag == "Fire Class B" || other.tag == "Fire Class C" || other.tag == "Fire Class D")
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
}
