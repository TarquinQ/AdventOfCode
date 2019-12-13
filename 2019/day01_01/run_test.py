#!/usr/bin/python3

import unittest
import daily_challenge as challenge


class TestBasic(unittest.TestCase):
    def test_training_data(self):
        given_set = [
            (12, 2),
            (14, 2),
            (1969, 654),
            (100756, 33583)
        ]
        given_values = [x[1] for x in given_set]
        total_expected = sum(given_values)

        total_actual = 0
        for item in given_set:
            mass, fuel = item[0], item[1]
            answer = challenge.calc_fuel(mass)
            self.assertEqual(fuel, answer)
            total_actual += answer
        self.assertEqual(total_actual, total_expected)

    def test_challenge(self):
        input_filename = "challenge_input.txt"
        my_answer = 3442987

        results = challenge.process_inputfile(input_filename)
        total_fuel = results[0]
        answer = total_fuel
        self.assertEqual(my_answer, answer)


if __name__ == '__main__':
    unittest.main()
