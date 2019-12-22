#!/usr/bin/python3

import unittest
import daily_challenge as challenge


class TestBasic(unittest.TestCase):
    def test_training_data(self):
        given_set = [
            ([1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50],
                [3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50]),

            ([1, 0, 0, 0, 99],
                [2, 0, 0, 0, 99]),

            ([2, 3, 0, 3, 99],
                [2, 3, 0, 6, 99]),

            ([2, 4, 4, 5, 99, 0],
                [2, 4, 4, 5, 99, 9801]),

            ([1, 1, 1, 4, 99, 5, 6, 0, 99],
                [30, 1, 1, 4, 2, 5, 6, 0, 99])
        ]

        for item in given_set:
            pre, post = item[0], item[1]
            post_new = challenge.process_opcode_space(opcode_space=pre.copy())
            self.assertEqual(post_new, post)

    def test_challenge(self):
        input_filename = "challenge_input.txt"
        my_answer = 1870666

        result = challenge.process_inputfile(input_filename)
        self.assertEqual(my_answer, result)


if __name__ == '__main__':
    unittest.main()
