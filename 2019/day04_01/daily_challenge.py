#!/usr/bin/python3

from typing import Any  # also: Dict, Tuple, Sequence
from dataclasses import dataclass


# This is done the slow, dumb way: generate all of the numbers in the range & test them.
# A better approach would be to generate the numbers according to the rules (within the range),
# eg incrementing unmbers only, and perform minor tests (duplicated digits)
# I hope we don;t reuse this code later, it's slightly inefficient


def process_range(start: int, stop: int) -> int:
    count = 0
    for test_pwd in range(start, stop+1):
        count += int(is_pwd_valid_norange(test_pwd))
    return count


def is_pwd_valid_norange(pwd: Any) -> bool:
    # It is a six-digit number
    # The value is within the range given in your puzzle input.
    # Two adjacent digits are the same(like 22 in 122345).
    # Going from left to right, the digits never decrease
    # they only ever increase or stay the same(like 111123 or 135679).

    if isinstance(pwd, str):
        try:
            pwd = int(pwd)
        except ValueError:
            return False

    if not isinstance(pwd, int):
        return False

    str_pwd = str(pwd)
    if not len(str_pwd) == 6:
        return False

    duplicate_digit_found = False
    prev_elem = -1
    for num_ in [int(x) for x in str_pwd]:
        if num_ < prev_elem:
            return False

        if num_ == prev_elem:
            duplicate_digit_found = True
        prev_elem = num_

    if not duplicate_digit_found:
        return False

    return True

@dataclass(frozen=True)
class Range:
    start: int
    stop: int


def is_pwd_inrange(pwd: int, accepted_range: Range) -> bool:
    return pwd >= accepted_range.start and pwd <= accepted_range.stop
