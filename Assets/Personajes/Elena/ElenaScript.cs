using UnityEngine;
using UnityEngine.UI;

namespace Personajes.Elena
{
    public class ElenaScript : MonoBehaviour
    {
        private Text dialog;
        // Start is called before the first frame update
        void Start()
        {
            dialog = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other)
        {
            dialog.text = "hola";
        }
    
        private void OnTriggerExit(Collider other)
        {
            dialog.text = "";
        }
    }
}
