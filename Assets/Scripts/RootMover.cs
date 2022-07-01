using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RootMover : MonoBehaviour
{
    Transform mRoot;
    [SerializeField] Direction direction;

    void Start()
    {
        mRoot = GameObject.FindGameObjectWithTag("RootObject").transform;
    }
    Vector2 merkezBulucu = Vector2.zero;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bound") && gameObject.CompareTag("MyBound"))
        {
            Transform tp = other.transform.parent;
            tp.parent = mRoot;
            mRoot.DOShakePosition(0.5f, 0.6f);
            mRoot.DOShakeScale(0.5f, 0.4f).OnComplete(() => mRoot.localScale = Vector3.one);
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
