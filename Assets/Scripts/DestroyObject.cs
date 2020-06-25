using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private ParticleSystem particula;
    // Start is called before the first frame update
    void Start()
    {
        particula = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (particula)
        {
            if (!particula.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
