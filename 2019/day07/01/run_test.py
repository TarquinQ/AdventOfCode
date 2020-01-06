#!/usr/bin/python3

import unittest
import daily_challenge as challenge
from dataclasses import dataclass
from typing import List


@dataclass
class KnownSolution:
    phase_setting_seq: List[int]
    max_thruster_signal: int
    Intcode_runtime: List[int]


class TestBasic(unittest.TestCase):
    def test_training_data(self):

        given_set = [
            KnownSolution(
                phase_setting_seq=[4, 3, 2, 1, 0],
                max_thruster_signal=43210,
                Intcode_runtime=[3, 15, 3, 16, 1002, 16,
                    10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0]
            ),

            KnownSolution(
                phase_setting_seq=[0, 1, 2, 3, 4],
                max_thruster_signal=54321,
                Intcode_runtime=[3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23,
                    101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0]
            ),

            KnownSolution(
                phase_setting_seq=[1, 0, 4, 3, 2],
                max_thruster_signal=65210,
                Intcode_runtime=[3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31,
                    -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1,
                    33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0]
            ),
        ]

        for soln in given_set:
            pass
            # post_new = challenge \
            #     .execute_Intcode_program(intcode_memspace=pre.copy())
            # self.assertEqual(post_new, post)

    @unittest.skip("Ignore for now")
    def test_challenge(self):
        input_filename = "challenge_input.txt"
        my_answer = 314

        result = challenge.process_inputfile(input_filename)
        self.assertEqual(my_answer, result)


if __name__ == '__main__':
    unittest.main()
