using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonGlow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject glow; // 拖拽glow对象到此处

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (glow != null)
            glow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (glow != null)
            glow.SetActive(false);
    }
}