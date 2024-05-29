using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Activar_dialog_Samira : MonoBehaviour
{
    public CinemachineVirtualCamera Virtual_Camera;
    [SerializeField] private Transform objetoAMover;
    [SerializeField] private Vector3 origen;
    [SerializeField] private Vector3 destino;
    [SerializeField] private Vector3 origenRotacion;
    [SerializeField] private Vector3 destinoRotacion;
    public GameObject Samira;
    public GameObject Dialeg;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == Samira)
            {
                StartCoroutine(MoureCamera());
            }
        }
    }

    IEnumerator MoureCamera()
    {
        
        // var puntA = Virtual_Camera.transform.position;
        // Virtual_Camera.transform.rotation = Quaternion.Euler(6.25f, 178.726f, 0.062f);
        Virtual_Camera.m_Lens.OrthographicSize = 1.5f;
        yield return StartCoroutine(MoureObjecte(objetoAMover, origen, destino, 1.0f));
        Debug.Log("Activar_dialog_Samira StartCoroutine1 MoureObjecte: Comença. ");
        yield return StartCoroutine(RotarObjeto(objetoAMover, origenRotacion, destinoRotacion, 1.0f));
        Debug.Log("Activar_dialog_Samira StartCoroutine1 RotarObjeto: Comença. ");
        Dialeg.SetActive(true);
        
        
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
        
        IEnumerator RotarObjeto(Transform objeto, Vector3 anguloInicial, Vector3 anguloFinal, float duracion)
        {
            float tiempoPasado = 0.0f;
            float ratio = 1.0f / duracion;

            while (tiempoPasado < 1.0f)
            {
                tiempoPasado += Time.deltaTime * ratio;
                objeto.rotation = Quaternion.Lerp(Quaternion.Euler(anguloInicial), Quaternion.Euler(anguloFinal), tiempoPasado);
                yield return null;
            }
        }
    }
    IEnumerator TornaCamera()
    {
        Dialeg.SetActive(false);
        // var puntA = Virtual_Camera.transform.position;
        // Virtual_Camera.transform.rotation = Quaternion.Euler(29.771f, 134.079f, 0.007f);
        Virtual_Camera.m_Lens.OrthographicSize = 7;
        yield return StartCoroutine(MoureObjecte(objetoAMover, destino, origen, 1.0f));
        Debug.Log("Activar_dialog_Samira StartCoroutine2 MoureObjecte: Comença. ");
        yield return StartCoroutine(RotarObjeto(objetoAMover, destinoRotacion, origenRotacion, 1.0f));
        Debug.Log("Activar_dialog_Samira StartCoroutine2 RotarObjeto: Comença. ");
        
        
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
        
        IEnumerator RotarObjeto(Transform objeto, Vector3 anguloInicial, Vector3 anguloFinal, float duracion)
        {
            float tiempoPasado = 0.0f;
            float ratio = 1.0f / duracion;

            while (tiempoPasado < 1.0f)
            {
                tiempoPasado += Time.deltaTime * ratio;
                objeto.rotation = Quaternion.Lerp(Quaternion.Euler(anguloInicial), Quaternion.Euler(anguloFinal), tiempoPasado);
                yield return null;
            }
        }
    }
}
