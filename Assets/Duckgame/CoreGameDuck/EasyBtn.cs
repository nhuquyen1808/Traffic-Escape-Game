using UnityEngine;
using System;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using UnityEditor;


//[CustomEditor(typeof(EasyBtn))]
/*public class AutoAddRef : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EasyBtn autoReference = (EasyBtn)target;
        if (autoReference.img == null)
        {
            autoReference.img = autoReference.GetComponent<Image>();
            if (autoReference.img == null)
            {
                Debug.LogWarning("img did not found");
            }
        }
    }
}*/
public class EasyBtn : MonoBehaviour/*, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler*/
{/*
    public Action PointerDownAction, PointerUpAction, PointerClickAction;
    public Image img;
    public void OnPointerClick(PointerEventData eventData)
    {
        transform.DOScale(0.9F, 0.2F).OnComplete(() =>
      {
          transform.DOScale(1f, 0.15F).OnComplete(() =>
          {
              PointerClickAction?.Invoke();
          });
      });
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(0.9F, 0.3F).OnComplete(() =>
        {
            transform.DOScale(1f, 0.3F).OnComplete(() =>
            {
                PointerDownAction?.Invoke();
            });
        });
        PointerDownAction?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PointerUpAction?.Invoke();
    }*/


}
