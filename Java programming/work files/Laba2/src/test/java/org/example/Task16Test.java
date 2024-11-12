package org.example;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

import java.util.List;

class Task16Test {

    @Test
    void testFindUniqueElementsDifferentSets() {
        int[] arrayA = {1, 2, 3, 4};
        int[] arrayB = {3, 4, 5, 6};
        List<Integer> result = Task16.findUniqueElements(arrayA, arrayB);
        assertIterableEquals(List.of(1, 2, 5, 6), result);
    }

    @Test
    void testFindUniqueElementsNoUniqueElements() {
        int[] arrayA = {1, 2, 3};
        int[] arrayB = {1, 2, 3};
        List<Integer> result = Task16.findUniqueElements(arrayA, arrayB);
        assertTrue(result.isEmpty());
    }

    @Test
    void testFindUniqueElementsOnlyInA() {
        int[] arrayA = {1, 2, 3};
        int[] arrayB = {4, 5, 6};
        List<Integer> result = Task16.findUniqueElements(arrayA, arrayB);
        assertIterableEquals(List.of(1, 2, 3, 4, 5, 6), result);
    }

}
