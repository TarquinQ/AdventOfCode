#!/usr/bin/python3

import unittest
import daily_challenge as challenge


class TestBasic(unittest.TestCase):
    def test_training_data(self):
        given_set = [
            (111111, True),
            (123789, False),
            (223450, False),
        ]

        for item in given_set:
            pwd, known_validity = item[0], item[1]
            is_valid = challenge.is_pwd_valid_norange(pwd=pwd)
            print("Testing validity: {0}; known: {1}, checked: {2}".format(
                pwd, known_validity, is_valid
            ))
            self.assertEqual(known_validity, is_valid)

    def test_challenge(self):
        input_range_start = 165432
        input_range_stop = 707912
        my_answer = 1716

        count = challenge.process_range(input_range_start, input_range_stop)
        self.assertEqual(my_answer, count)


if __name__ == '__main__':
    unittest.main()
