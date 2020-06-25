using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogo : MonoBehaviour
{

    private ParticleSystem particulaFogo;
	public int valorEmissaoInicialFogo = 5;
	private int valorEmissao = 0;
    public int razaoFogo;
	private bool podeDiminuirFogo = true;	//Pra que não fique chamando o fogo sem que tenha passado 1 segundo de delay

    // Use this for initialization
    void Start()
    {
        particulaFogo = GetComponent<ParticleSystem>();
        valorEmissao = valorEmissaoInicialFogo;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator diminuirFogo()
    {
        if (podeDiminuirFogo == true){
            podeDiminuirFogo = false;

            if (valorEmissao > 0){   //Se ainda houver emissão
                Debug.Log("AgenteExtintor.cs: Diminuindo fogo!");
                yield return new WaitForSeconds(1.0f);

                //Alterando Y da escala
                Vector3 escala = particulaFogo.shape.scale;  //Pega a escala antiga
                escala.y = escala.y - 0.2f; //Reduz a escala y
                escala.x = escala.x - 0.2f; //Reduz a escala x
                                            //Aplicando nova escala - https://answers.unity.com/questions/1467966/how-do-i-change-the-shape-scale-in-the-particle-sy.html
                var shape = particulaFogo.shape; //Não podia fazer tudo em uma linha "fogo.shape.scale = escala", como explicado no link acima. Por isso que tá separado.
                shape.scale = escala;   //Aplica a escala alterada

                //Alterando valor da emissão
                valorEmissao = valorEmissao - razaoFogo;   //Atualiza para o novo valor emissao, para que na próxima vez que esse método for chamado, ele saiba o novo valor
                                                    //Aplicando nova emissão
                var emission = particulaFogo.emission;   //Tá separado pelo mesmo motivo do shape
                emission.rateOverTime = valorEmissao;   //Aplica o valor emissao reduzido

                podeDiminuirFogo = true;    //Para que ele tenha chance de entrar novamente nessa condição
            }else{
                podeDiminuirFogo = false;
                particulaFogo.Stop();    //Para o fogo totalmente
                yield return new WaitForSeconds(1f);    //Dá um tempo pra que o método acima seja executado normal antes de destruir o objeto
            }
        }
    }
}