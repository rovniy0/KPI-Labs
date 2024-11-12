package org.example;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

class Task26Test {

    @Test
    void testReverseArray() {
        int[] arrayA = {1, 2, 3, 4, 5};
        int[] expectedArrayB = {5, 4, 3, 2, 1}; // Очікую
        int[] result = Task26.reverseArray(arrayA);
        assertArrayEquals(expectedArrayB, result);
    }
    @Test
    void testReverseArraySingleElement() {
        int[] arrayA = {10};
        int[] expectedArrayB = {10};
        int[] result = Task26.reverseArray(arrayA);
        assertArrayEquals(expectedArrayB, result);
    }
    @Test
    void testReverseArrayEmpty() {
        int[] arrayA = {};
        int[] expectedArrayB = {};
        int[] result = Task26.reverseArray(arrayA);
        assertArrayEquals(expectedArrayB, result);
    }
}
