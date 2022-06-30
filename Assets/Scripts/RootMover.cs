using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RootMover : MonoBehaviour
{
    Transform mRoot;
    [SerializeField] Direction direction;
    PlayerController controller;

    void Start()
    {
        mRoot = GameObject.FindGameObjectWithTag("RootObject").transform;
        controller = mRoot.GetComponent<PlayerController>();
    }
    Vector2 merkezBulucu = Vector2.zero;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bound") && gameObject.CompareTag("MyBound"))
        {
            Transform tp = other.transform.parent;
            Debug.Log("aaaaa");
            tp.parent = mRoot;
            mRoot.DOShakePosition(0.5f, 0.6f);
            mRoot.DOShakeScale(0.5f, 0.4f).OnComplete(() => mRoot.localScale = Vector3.one);
          //  GameManager.instance.brickGoal++;
            switch (direction)
            {
                case Direction.Left:
                    SetOthersPos(tp, Vector3.left);
                    
                    SetChildPoses(Vector3.right);
                    break;
                case Direction.Right:
                    SetOthersPos(tp, Vector3.right);
                    
                    SetChildPoses(Vector3.left);
                    break;
                case Direction.Up:
                    SetOthersPos(tp, Vector3.forward);
                   
                    SetChildPoses(Vector3.back);
                    break;
                case Direction.Down:
                    SetOthersPos(tp, Vector3.back);
                 
                    SetChildPoses(Vector3.forward);
                    break;
                default:
                    break;
            }
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            
            foreach (Transform item in tp)
            {
                item.tag = "MyBound";
            }
        }
        
        else if (other.gameObject.CompareTag("FinalBound"))
        {
            
          /*  if (mRoot.childCount -1 == GameManager.instance.finalpoints.childCount)
            {
                if (controller.a == GameManager.instance.finalpoints.childCount)
                {
                    controller.transform.position = controller.finalPos.position;
                    mRoot.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                    //  controller.enabled = false;
                    GameManager.instance.finalMoment?.Invoke();
                }
            }
            else
            {
                mRoot.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
              //  controller.enabled = false;
                GameManager.instance.failMoment?.Invoke();
            }*/
                
        }
    }


    void SetOthersPos(Transform tr, Vector3 dir)
    {
        tr.position = transform.parent.position + dir * 4;
      
    }
    void SetChildPoses(Vector3 dir)
    {
        foreach (Transform item in mRoot)
        {
            item.position = item.position + dir * 2;
        }
    }

}
public enum Direction
{
    Left,
    Right,
    Up,
    Down
}
