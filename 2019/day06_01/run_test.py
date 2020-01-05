#!/usr/bin/python3

import unittest
import daily_challenge as challenge


class TestBasic(unittest.TestCase):
    def test_training_data(self):
        given_set = [
            (['COM)B',
              'B)C',
              'C)D',
              'D)E',
              'E)F',
              'B)G',
              'G)H',
              'D)I',
              'E)J',
              'J)K',
              'K)L',
              ],
            42)
        ]

        for item in given_set:
            dependency_graph_descr, num_orbits = item[0], item[1]
            calc_orbit_count = challenge.process_orbit_list(dependency_graph_descr)
            self.assertEqual(num_orbits, calc_orbit_count)

    @unittest.skip("Ignore for now")
    def test_challenge(self):
        input_filename = "challenge_input.txt"
        my_answer = 314

        result = challenge.process_inputfile(input_filename)
        self.assertEqual(my_answer, result)


if __name__ == '__main__':
    unittest.main()
