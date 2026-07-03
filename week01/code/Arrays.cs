public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // === PLAN ===
        // 1. Create and initialize a new array of doubles called 'multiples' with a fixed size equal to the 'length' argument.
        // 2. Set up a standard for-loop that starts at index 0 and iterates up to 'length - 1'.
        // 3. Inside the loop, compute the multiple value for the current position. 
        //    Since the first multiple is number * 1, multiply 'number' by (current index + 1).
        // 4. Assign this calculated value to the corresponding index in the 'multiples' array.
        // 5. Once the loop finishes processing all positions, return the populated 'multiples' array.

        // 1. Initialize the array with the requested length
        double[] multiples = new double[length];

        // 2. Loop through each index to fill the array
        for (int i = 0; i < length; i++)
        {
            // 3 & 4. Calculate the multiple and assign it to the array index
            multiples[i] = number * (i + 1);
        }

        // 5. Return the completed dynamic array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // === PLAN ===
        // 1. Check for basic defensive edge cases: if the list is null, has 1 or fewer elements, or rotation amount is 0, exit early.
        // 2. Use the modulo operator (%) to normalize the rotation 'amount' against the actual size of the list. 
        //    This safely handles situations where the rotation amount matches or exceeds the list length.
        // 3. If the effective rotation amount ends up being 0 after normalization, no changes are needed, so exit.
        // 4. Extract the last 'amount' elements from the list using GetRange to represent the segment shifting to the front.
        // 5. Extract the remaining starting elements from index 0 up to (data.Count - amount) to represent the segment shifting to the back.
        // 6. Clear all current entries from the original 'data' list to reset its contents.
        // 7. Rebuild the 'data' list in-place by using AddRange to append the back segment first, followed immediately by the front segment.

        // 1. Handle initial safety checks
        if (data == null || data.Count <= 1 || amount <= 0)
        {
            return;
        }

        // 2 & 3. Normalize amount and verify if actual work is needed
        amount = amount % data.Count;
        if (amount == 0)
        {
            return;
        }

        // 4. Extract the moving segments using list slicing
        List<int> backSegment = data.GetRange(data.Count - amount, amount);
        List<int> frontSegment = data.GetRange(0, data.Count - amount);

        // 5. Clear the initial reference collection 
        data.Clear();

        // 6 & 7. Append back and front segments in their new positions to complete rotation
        data.AddRange(backSegment);
        data.AddRange(frontSegment);
    }
}
