using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherEspumaMecanica : MonoBehaviour
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
        if (other.tag == "Fire Class A" || other.tag == "Fire Class B")
        {
            Fogo ScriptFogo = other.GetComponent<Fogo>();
            StartCoroutine(ScriptFogo.diminuirFogo());
        }
        else if (other.tag == "Fire Class C" || other.tag == "Fire Class D" || other.tag == "Fire Class K")
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
