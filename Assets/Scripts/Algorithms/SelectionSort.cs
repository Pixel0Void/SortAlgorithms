using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSort : BaseSort, ISortAlgorithm
{
    public void Sort(List<Bar> bars, float delayTime, OrderEnum order, Action onComplete)
    {
        StartCoroutine(Sorting(bars, delayTime, order, onComplete));
    }

    private IEnumerator Sorting(List<Bar> bars, float delayTime, OrderEnum order, Action onComplete)
    {
        int selectedIndex = 0;
        int max = bars.Count;

        for (int i = 0; i < max - 1; i++)
        {
            selectedIndex = i;
            for (int j = i + 1; j < max; j++)
            {
                if (CompareTool.CompareValues(bars[selectedIndex].Value, bars[j].Value, order))
                {
                    selectedIndex = j;
                }
            }

            if (selectedIndex != i)
            {
                bars[selectedIndex].SetColor(m_ModifiedColor);
                bars[i].SetColor(m_ModifiedColor);

                yield return new WaitForSeconds(delayTime);

                int temp = bars[selectedIndex].Value;
                bars[selectedIndex].Value = bars[i].Value;
                bars[i].Value = temp;

                bars[selectedIndex].ResetColorToOriginal();
                bars[i].ResetColorToOriginal();
            }
        }

        onComplete();
    }
}
