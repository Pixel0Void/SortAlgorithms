using UnityEngine;

public enum AlgorithmsEnum
{
    Bubble,
    Selection,
    Insertion,
    Shell,
    Quick
}

public enum OrderEnum
{
    Ascending,
    Descending
}


public class BaseSort : MonoBehaviour
{
    [SerializeField] protected Color m_ModifiedColor;
}
