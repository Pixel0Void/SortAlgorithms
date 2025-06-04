public static class CompareTool
{
    public static bool CompareValues(int first, int second, OrderEnum order)
    {
        bool answer = false;

        switch (order)
        {
            case OrderEnum.Ascending:
                answer = first > second ? true : false;
                break;
            case OrderEnum.Descending:
                answer = first < second ? true : false;
                break;
        }

        return answer;
    }
}
