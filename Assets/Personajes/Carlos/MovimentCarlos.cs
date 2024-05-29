using System;
using UnityEngine;

namespace Personajes.Carlos
{
    public class MovimentCarlos : MonoBehaviour
    {
        [SerializeField] private float velocitat = 3f;

        private bool moving = false;

        private Animator animator;

        private GameObject spawn;

        [HideInInspector]public string sceneName = "";

        // Start is called before the first frame update
        void Start()
        {

            if (PlayerPrefs.HasKey("fase"))
            {
                PlayerPrefs.SetInt("fase",0);
            }
        
            animator = GetComponent<Animator>();
            if (sceneName != "")
            {
                spawn = GameObject.FindGameObjectWithTag("tp-" + sceneName);
            }/*else
        {
            spawn = GameObject.Find("Spawn");
        }*/
        
            if (spawn)
            {
            
                Vector3 pos = spawn.transform.position;
                transform.position = new Vector3(pos.x, 0, pos.z);
            }
        }


        // Update is called once per frame
        void Update()
        {
            if (moving && Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
            {
                moving = false;
                swapAnim();
            }
            if (!moving && (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0))
            {
                moving = true;
                swapAnim();
            }
            transform.Translate(Vector3.forward * Time.deltaTime * Math.Max(Math.Abs(Input.GetAxis("Vertical")),Math.Abs(Input.GetAxis("Horizontal")))*velocitat);
            transform.LookAt(transform.position + new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        }

        void swapAnim()
        {
            if (moving)
            {
                animator.SetTrigger("walk");
            }   
            else
            {
                animator.SetTrigger("idle");
            }
        }
    }
}
