using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AdrianRutina : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        animator = GetComponent<Animator>();
        var puntB = new Vector3(-21,0,-15);
        var puntC = new Vector3(-16,0,-13);
        var puntD = new Vector3(-13,0,-17);
        while (true)
        {
            yield return StartCoroutine(CorrerPers(transform,puntB,"IdleRun"));
            yield return StartCoroutine(AccioPers(transform,puntB,6.0f, "RunIdle"));
            yield return StartCoroutine(AccioPers(transform,puntB,15.0f, "IdleTalk"));
            yield return StartCoroutine(AccioPers(transform,puntB,6.0f, "TalkIdle"));
            yield return StartCoroutine(CorrerPers(transform,puntC,"IdleRun", new float[]{0.3f,0.6f,0.8f}));
            yield return StartCoroutine(AccioPers(transform,puntC,6.0f, "RunIdle"));
            yield return StartCoroutine(CorrerPers(transform,puntD,"IdleRun"));
            yield return StartCoroutine(AccioPers(transform,puntD,6.0f, "RunIdle"));
            yield return StartCoroutine(AccioPers(transform,puntD,2.7f, "IdleJump"));
            yield return StartCoroutine(AccioPers(transform,puntD,6.0f, "JumpIdle"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator AccioPers(Transform transform, Vector3 final, float temps, string animacio)
    {
        Vector3 inici = transform.position;
        animator.SetTrigger(animacio);
        var i= 0.0f; 
        var rati= 1.0f/temps;
        transform.LookAt(final);
        while (i < 1.0f)
        {
            i += Time.deltaTime * rati;
            transform.position = Vector3.Lerp(inici, final, i);
            yield return null;
        }
    }public IEnumerator CorrerPers(Transform transform, Vector3 final, string animacio, float[] salts = null)
    {
        animator.SetTrigger(animacio);
        Vector3 inici = transform.position;
        var distancia = Vector3.Distance(inici, final);
        var velocitat = 2f;
        var temps = distancia / velocitat;
        var i= 0.0f; 
        var rati= 1.0f/temps;
        transform.LookAt(final);
        var jumps = salts!=null ? salts.Length : 0;
        var jump = 0 ;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rati;;
            if (salts != null && jumps>jump && salts[jump]<i)
            {
                animator.SetTrigger("RunJump");
                animator.SetTrigger("JumpRun");
                jump++;
            }
            transform.position = Vector3.Lerp(inici, final, i);
            yield return null;
        }
    }
}
