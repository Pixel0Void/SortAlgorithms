using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : BaseSort, ISortAlgorithm
{
    public void Sort(List<Bar> bars, float delayTime, Action onComplete)
    {
        StartCoroutine(Sorting(bars, delayTime, onComplete));
    }

    private IEnumerator Sorting(List<Bar> bars, float delayTime, Action onComplete)
    {
        int max = bars.Count;
        int temp = 0;
        bool swapped = false;

        for (int i = 0; i < max - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < max - i - 1; j++)
            {
                if (bars[j].Value < bars[j + 1].Value)
                {
                    bars[j].SetColor(m_ModifiedColor);
                    bars[j + 1].SetColor(m_ModifiedColor);

                    yield return new WaitForSeconds(delayTime);

                    temp = bars[j].Value;
                    bars[j].Value = bars[j + 1].Value;
                    bars[j + 1].Value = temp;
                    swapped = true;

                    bars[j].ResetColorToOriginal();
                    bars[j + 1].ResetColorToOriginal();
                }
            }

            if (!swapped)
                break;
        }

        onComplete();
    }
}
