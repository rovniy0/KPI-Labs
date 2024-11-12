package org.example;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

class Task12Test {

    @Test
    void testStrictlyIncreasingSequence() {
        int[] array = {1, 2, 3, 4, 5};
        String result = Task12.checkSequence(array);
        assertEquals("Строго зростаюча послідовність", result);
    }

    @Test
    void testStrictlyDecreasingSequence() {
        int[] array = {5, 4, 3, 2, 1};
        String result = Task12.checkSequence(array);
        assertEquals("Строго спадна послідовність", result);
    }

    @Test
    void testUnorderedSequence() {
        int[] array = {3, 1, 4, 2};
        String result = Task12.checkSequence(array);
        assertEquals("Елементи масиву не впорядковані", result);
    }

    @Test
    void testSingleElement() {
        int[] array = {5};
        Exception exception = assertThrows(IllegalArgumentException.class, () -> {
            Task12.checkSequence(array);
        });
        assertEquals("Масив повинен містити принаймні два елементи", exception.getMessage());
    }

}
