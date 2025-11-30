using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [Header("缩放")]
    [SerializeField] private Vector3 normalScale = Vector3.one;
    [SerializeField] private Vector3 hoverScale = new Vector3(1.05f, 1.05f, 1);
    [Header("时间间隔")]
    [SerializeField] private float _scaleDuration = 0.1f;
    [SerializeField] private float _clickDuration=0.1f;
   

   
  

    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
       
    }
    private void OnDestroy() => _button.onClick.RemoveListener(OnClick);

    /* ====== 悬停 ====== */
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(hoverScale, _scaleDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(normalScale, _scaleDuration);
    }

    /* ====== 点击 ====== */
    private void OnClick()
    {
        //改变大小
        transform.DOScale(normalScale * 0.95f, 0.1f)
                 .OnComplete(() => transform.DOScale(normalScale, _clickDuration));
    }
}
