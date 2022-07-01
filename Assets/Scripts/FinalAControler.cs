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
        if (mRoot.childCount - 1 == GameManager.Instance.finalpoints.childCount)
        {
            if (controller.a == GameManager.Instance.finalpoints.childCount)
            {
                mRoot.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GameManager.Instance.finalMoment?.Invoke();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Cube"))
            controller.a--;
    }
}
