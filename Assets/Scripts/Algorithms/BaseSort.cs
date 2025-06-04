using UnityEngine;

public enum AlgorithmsEnum
{
    Bubble,
    Selection,
    Insertion,
    Shell,
    Quick
}

public class BaseSort : MonoBehaviour
{
    [SerializeField] protected Color m_ModifiedColor;
}
