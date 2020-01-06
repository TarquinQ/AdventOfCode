#!/usr/bin/python3

import unittest
import daily_challenge as challenge


class TestBasic(unittest.TestCase):
    def test_training_data(self):
        given_set = [
            (['R8', 'U5', 'L5', 'D3'],
             ['U7', 'R6', 'D4', 'L4'],
             30),

            (['R75', 'D30', 'R83', 'U83', 'L12', 'D49', 'R71', 'U7', 'L72'],
             ['U62', 'R66', 'U55', 'R34', 'D71', 'R55', 'D58', 'R83'],
             610),

            (['R98', 'U47', 'R26', 'D63', 'R33', 'U87', 'L62', 'D20', 'R33', 'U53', 'R51'],
             ['U98', 'R91', 'D20', 'R16', 'D67', 'R40', 'U7', 'R15', 'U6', 'R7'],
             410),
        ]

        for item in given_set:
            wire1, wire2, known_distance = item[0], item[1], item[2]
            closest_point = challenge.execute_wire_comparison(
                wire1_trace=wire1, wire2_trace=wire2)
            self.assertEqual(known_distance, closest_point)

    def test_challenge(self):
        input_filename = "challenge_input.txt"
        my_answer = 164012

        closest_point = challenge.process_inputfile(input_filename)
        self.assertEqual(my_answer, closest_point)


if __name__ == '__main__':
    unittest.main()
