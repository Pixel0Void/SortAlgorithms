public static class RandomGenerator
{
    public static int[] Generate(int size, uint minRange, uint maxRange)
    {
        int[] ints = new int[size];
        for (int i = 0; i < size; i++)
        {
            ints[i] = UnityEngine.Random.Range((int)minRange, (int)maxRange + 1);
        }
        return ints;
    }
}
