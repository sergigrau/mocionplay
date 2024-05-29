using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moure_Player : MonoBehaviour
{
    [SerializeField] private Transform objetoAMover;
    [SerializeField] private Vector3 destino1;
    [SerializeField] private Vector3 origen2;
    [SerializeField] private Vector3 destino2;
    
    public static int Inv_MourePlayer;
    
    private Animator animator;

    IEnumerator Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        animator = objetoAMover.GetComponent<Animator>();
        
        objetoAMover.transform.rotation = Quaternion.Euler(0, 0, 0);
        var puntA = objetoAMover.transform.position;
        yield return StartCoroutine(MoureObjecte(objetoAMover, puntA, destino1, 1.0f));
        Debug.Log("MourePlayer StartCoroutine1 MoureObjecte: Comença. ");
        animator.SetTrigger("idle");
        
        Inv_MourePlayer = 1;
        
        IEnumerator MoureObjecte(Transform transformObjecte, Vector3 posInicial, Vector3 posFinal, float temps)
        {
            objetoAMover.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetTrigger("walk");
            var i = 0.0f;
            var rati = 1.0f / temps;
            while (i < 1.0f)
            {
                i += Time.deltaTime * rati;
                transformObjecte.position = Vector3.Lerp(posInicial, posFinal, i);
                yield return null;
            }
        }
    }
    
    IEnumerator Anar_Avia()
    {
        objetoAMover.transform.rotation = Quaternion.Euler(0, 0, 0);
        yield return StartCoroutine(Moure_Fins_Avia(objetoAMover, origen2, destino2, 2.0f));
        Debug.Log("MourePlayer StartCoroutine2 MoureObjecte: Comença. ");
        IEnumerator Moure_Fins_Avia(Transform transformObjecte, Vector3 posInicial, Vector3 posFinal, float temps)
        {
            animator.SetTrigger("walk");
            var i = 0.0f;
            var rati = 1.0f / temps;
            while (i < 1.0f)
            {
                i += Time.deltaTime * rati;
                transformObjecte.position = Vector3.Lerp(posInicial, posFinal, i);
                yield return null;
            }
        }
        animator.SetTrigger("idle");
    }

    void Update()
    {
        // objetoAMover.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    
    
    /*[SerializeField] private Vector3 destino1;
    

    IEnumerator Start()
    {
        
        var puntA = transform.position;
        //while (true)
        //{
            yield return StartCoroutine(MoureObjecte(transform, puntA, destino1, 1.0f));
            Debug.Log("MourePlayer StartCoroutine1 MoureObjecte: Comença. ");

            //}

        void Update()
        {

        }

        IEnumerator MoureObjecte(Transform transformObjecte, Vector3 posInicial, Vector3 posFinal, float temps)
        {
            var i = 0.0f;
            var rati = 1.0f / temps;
            while (i < 1.0f)
            {
                i += Time.deltaTime * rati;
                transformObjecte.position = Vector3.Lerp(posInicial, posFinal, i);
                yield return null;
            }
        }
        
        
    }*/
}
