using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIStarMove : MonoBehaviour
{
    [SerializeField] Transform hedef;
    private void OnEnable()
    {
        transform.DOScale(Vector3.one, 1);
        transform.DOLocalMove(hedef.localPosition, 1).OnComplete(() =>
        {
            hedef.gameObject.SetActive(false);
            transform.DOShakePosition(1, 10);
            transform.parent.GetChild(transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
            if(gameObject.CompareTag("Sayi"))
                gameObject.SetActive(false);
        });
    }
}
