package org.example;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

class Task7Test {
    @Test
    public void testFindMinDifferencePositiveNumbers() {
        int[] array = {4, 9, 1, 7, 3};
        int result = Task7.findMinDifference(array);
        assertEquals(1, result);
    }

    @Test
    void testFindMinDifferenceNegativeNumbers() {
        int[] array = {-5, -2, -8, -3};
        int result = Task7.findMinDifference(array);
        assertEquals(1, result);
    }

    @Test
    void testFindMinDifferenceSameNumbers() {
        int[] array = {1, 1, 1, 1};
        int result = Task7.findMinDifference(array);
        assertEquals(0, result);
    }

    @Test
    void testFindMinDifferenceSingleElement() {
        int[] array = {10};
        Exception exception = assertThrows(IllegalArgumentException.class, () -> {
            Task7.findMinDifference(array);
        });
        assertEquals("Масив повинен містити принаймні два елементи.", exception.getMessage());
    }
}