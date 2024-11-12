package org.example;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

class Task22Test {

    @Test
    void testCreateIndexArraySortedDescending() {
        int[] arrayA = {5, 3, 8, 1, 4};
        int[] expectedIndexArray = {2, 0, 4, 1, 3}; // Індикація елементів у порядку убування
        int[] result = Task22.createIndexArray(arrayA);
        assertArrayEquals(expectedIndexArray, result);
    }

    @Test
    void testCreateIndexArrayAllEqual() {
        int[] arrayA = {7, 7, 7};
        int[] expectedIndexArray = {0, 1, 2}; // Індикація елементів, порядок може бути довільним
        int[] result = Task22.createIndexArray(arrayA);
        assertArrayEquals(expectedIndexArray, result);
    }

    @Test
    void testCreateIndexArraySingleElement() {
        int[] arrayA = {10};
        int[] expectedIndexArray = {0}; // Єдиний елемент
        int[] result = Task22.createIndexArray(arrayA);
        assertArrayEquals(expectedIndexArray, result);
    }

    @Test
    void testCreateIndexArrayEmpty() {
        int[] arrayA = {};
        int[] expectedIndexArray = {}; // Порожній масив
        int[] result = Task22.createIndexArray(arrayA);
        assertArrayEquals(expectedIndexArray, result);
    }
}
