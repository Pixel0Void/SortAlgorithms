using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionSort : BaseSort, ISortAlgorithm
{
    public void Sort(List<Bar> bars, float delayTime, OrderEnum order, Action onCompelete)
    {
        StartCoroutine(Sorting(bars, delayTime, order, onCompelete));
    }

    private IEnumerator Sorting(List<Bar> bars, float delay, OrderEnum order, Action onComplete)
    {
        int valueToInsert;
        int holePosition;

        for (int i = 1; i < bars.Count; i++)
        {
            valueToInsert = bars[i].Value;
            holePosition = i - 1;

            while (holePosition >= 0 && CompareTool.CompareValues(bars[holePosition].Value, valueToInsert, order))
            {
                bars[holePosition + 1].Value = bars[holePosition].Value;
                int tempHole = holePosition;
                holePosition--;

                bars[tempHole].SetColor(m_ModifiedColor);
                bars[tempHole + 1].SetColor(m_ModifiedColor);

                yield return new WaitForSeconds(delay);

                bars[tempHole].ResetColorToOriginal();
                bars[tempHole + 1].ResetColorToOriginal();
            }

            bars[holePosition + 1].Value = valueToInsert;
            bars[holePosition + 1].SetColor(m_ModifiedColor);
            yield return new WaitForSeconds(delay);
            bars[holePosition + 1].ResetColorToOriginal();
        }

        onComplete();
    }
}
