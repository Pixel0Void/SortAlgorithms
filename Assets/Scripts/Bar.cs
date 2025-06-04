using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]
public class Bar : MonoBehaviour
{
    private RectTransform m_Transform;
    private Image m_Image;
    private Color m_OriginalColor;

    private int m_Value;
    public int Value
    {
        set
        {
            m_Value = value;
            m_Transform.sizeDelta = new Vector2(m_Transform.sizeDelta.x, m_Value);
        }
        get => m_Value;
    }

    private void Awake()
    {
        m_Transform = GetComponent<RectTransform>();
        m_Image = GetComponent<Image>();
        m_OriginalColor = m_Image.color;
    }

    public void SetColor(Color color)
    {
        m_Image.color = color;
    }

    public void ResetColorToOriginal()
    {
        m_Image.color = m_OriginalColor;
    }
}
