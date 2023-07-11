using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private Image _image;
    [SerializeField] private Sprite _default, _pressed;
    [SerializeField] private AudioSource _compressClip, _uncompressClip;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = _pressed;
        AudioManager.Instance.PlaySFX("compress");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = _default;
        AudioManager.Instance.PlaySFX("uncompress");
    }

    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
    
}
