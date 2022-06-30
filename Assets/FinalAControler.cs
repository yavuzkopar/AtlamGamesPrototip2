using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAControler : MonoBehaviour
{
    Transform mRoot;
    
    PlayerController controller;

    void Start()
    {
        mRoot = GameObject.FindGameObjectWithTag("RootObject").transform;
        controller = mRoot.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cube"))
            controller.a++;
        if (mRoot.childCount - 1 == GameManager.instance.finalpoints.childCount)
        {
            if (controller.a == GameManager.instance.finalpoints.childCount)
            {
            //    controller.transform.position = controller.finalPos.position;
                mRoot.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                //  controller.enabled = false;
                GameManager.instance.finalMoment?.Invoke();
            }
         /*   else
            {
                mRoot.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                //  controller.enabled = false;
                GameManager.instance.failMoment?.Invoke();
            }*/
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Cube"))
            controller.a--;
    }
}
