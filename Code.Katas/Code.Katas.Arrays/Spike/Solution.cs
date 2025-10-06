namespace Code.Katas.Arrays.Spike;

public static class Solution
{
    /// <summary>
    /// Given an array of integers, returns the longest spike that can be formed from the array.
    /// A spike is defined as a sequence of numbers that first strictly increases and then strictly decreases.
    /// </summary>
    public static int[] Execute(int[] values)
    {
        if (values.Length < 2)
        {
            return [];
        }

        var sortedValues = values.OrderBy(v => v).ToArray();

        var frequencies = new Dictionary<int, int>();
        var queue = new Queue<int>();

        for (int i = 0; i < sortedValues.Length; i++) 
        {
            var current = sortedValues[i];

            if (!frequencies.ContainsKey(current))
            {
                // initialize frequency for the current number
                frequencies[current] = 0;
            }

            // increment frequency for the current number
            frequencies[current]++;

            if (frequencies[current] > 2)
            {
                // skip numbers that appear more than twice
                continue;
            }
            
            queue.Enqueue(current);
        }

        // use two pointers to build the spike from the outside in
        var spike = new int[queue.Count];
        var isLeft = true;
        var left = 0;
        var rigth = spike.Length - 1;

        while (queue.Count > 0)
        { 
            var current = queue.Dequeue();

            if (queue.Count == 1 && current == queue.Peek())
            {
                // skip the last number if it's a duplicate
                break;
            }

            if (isLeft)
            {
                spike[left] = current;
                left++;
                isLeft = false;
            }
            else
            {
                spike[rigth] = current;
                rigth--;
                isLeft = true;
            }
        }

        return spike;
    }
}
