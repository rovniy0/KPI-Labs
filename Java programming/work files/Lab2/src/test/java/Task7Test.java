package src.test.java;

import org.junit.Test;
import static org.junit.Assert.*;

public class Task7Test {

    @Test
    public void testFindMinDifferencePositiveNumbers() {
        int[] array = {4, 9, 1, 7, 3};
        int result = ArrayDifference.findMinDifference(array);
        assertEquals(1, result);
    }

}
