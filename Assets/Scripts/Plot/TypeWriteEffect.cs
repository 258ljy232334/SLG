using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
//通过协程实现逐步打字的效果
public class TypeWriteEffect : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI WriteText;
    [SerializeField]
    private float WaitTime = 0.5f;

    private Coroutine _typeWriteCoroutine;//打字协程
    private bool _isTyping=false;


    public bool IsTyping => _isTyping;

    public void StartType(string text)
    {
        if(_typeWriteCoroutine!=null)
        {
            StopCoroutine(_typeWriteCoroutine);
        }
        _typeWriteCoroutine =StartCoroutine(TypeLine(text));
    }
    //打字协程
    private IEnumerator TypeLine(string text)
    {
        _isTyping = true;
        WriteText.text = text;
        WriteText.maxVisibleWords = 0;
        for(int i=0;i<text.Length;i++)
        {
            WriteText.maxVisibleWords++;
            yield return new WaitForSeconds(WaitTime);
        }
        _isTyping= false;
    }
    //直接完成当前行
    public void CompleteLine()
    {
        _isTyping = false;
        if (_typeWriteCoroutine != null)
        {
            StopCoroutine(_typeWriteCoroutine);
        }
        WriteText.maxVisibleCharacters = WriteText.text.Length;
    }
}
