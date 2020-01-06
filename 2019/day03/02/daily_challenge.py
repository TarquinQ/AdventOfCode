#!/usr/bin/python3

from typing import List  # also: Dict, Tuple, Sequence
from dataclasses import dataclass


def process_inputfile(filepath: str) -> int:
    list_strs = get_list_strs_csv(filepath)
    lowest_point = execute_wire_comparison(wire1_trace=list_strs[0], wire2_trace=list_strs[1])

    return lowest_point


def execute_wire_comparison(wire1_trace: List[str], wire2_trace: List[str]):
    wire1 = WireTrail()
    wire2 = WireTrail()

    # print("Instatiating Wire1: {0}".format(wire1_trace))
    for movement in wire1_trace:
        wire1.move(movement)

    # print("Instatiating Wire2: {0}".format(wire2_trace))
    for movement in wire2_trace:
        wire2.move(movement)

    # print("Path for Wire1: {0}".format(wire1.wire_path))
    # print("Path for Wire2: {0}".format(wire2.wire_path))

    common_points = wire1.wire_path.intersection(wire2.wire_path)

    # print("Common Points:")
    # print(common_points)

    if common_points == set():
        return Point(x=0, y=0, steps=0)

    starting_point = iter(common_points)
    lowest_point1 = next(starting_point)  # Random starting point 1
    lowest_point2 = next(starting_point)  # Random starting point 2
    lowest_steps = lowest_point1.steps*20 + lowest_point2.steps*20
    for point in common_points:
        # print("Now examining common point: {0}".format(point))
        point_wire1 = None
        point_wire2 = None
        for path_point in wire1.wire_path:
            if path_point == point:
                point_wire1 = path_point
        for path_point in wire2.wire_path:
            if path_point == point:
                point_wire2 = path_point

        # print("Points in each wire; wire1: {0}; wire2: {1}".format(point_wire1, point_wire2))
        steps = point_wire1.steps + point_wire2.steps

        if steps < lowest_steps:
            lowest_steps = steps

    return lowest_steps


@dataclass(frozen=True)
class Point:
    x: int
    y: int
    steps: int

    def copy(self):
        return Point(x=self.x, y=self.y)

    def manhattan_distance(self):
        return abs(self.x) + abs(self.y)

    def __key(self):
        return (self.x, self.y)

    def __hash__(self):
        return hash(self.__key())

    def __eq__(self, other):
        if isinstance(other, type(self)):
            return self.__key() == other.__key()
        return NotImplemented


class WireTrail:
    def __init__(self):
        self.curr_point = Point(0, 0, 0)
        self.wire_path = set()
        self.curr_steps = 0

    def move(self, movement: str):
        direction = movement[0]
        magnitude = int(movement[1:])

        # print("Executing Wire Movement. CurrPoint: {0}; Movement: {1} (dir:{2};mag:{3})".format(
        #     self.curr_point, movement, direction, magnitude
        # ))

        if direction == "U":
            self.move_up(magnitude=magnitude)
        elif direction == "D":
            self.move_down(magnitude=magnitude)
        elif direction == "L":
            self.move_left(magnitude=magnitude)
        elif direction == "R":
            self.move_right(magnitude=magnitude)

    def move_up(self, magnitude: int):
        self.move_vert(magnitude=magnitude, multiplier=1)

    def move_down(self, magnitude: int):
        self.move_vert(magnitude=magnitude, multiplier=-1)

    def move_right(self, magnitude: int):
        self.move_horiz(magnitude=magnitude, multiplier=1)

    def move_left(self, magnitude: int):
        self.move_horiz(magnitude=magnitude, multiplier=-1)

    def move_vert(self, magnitude: int, multiplier: int):
        # generate a trail of all traversed points
        for i in range(1, magnitude+1):
            self.curr_steps += 1
            new_y = self.curr_point.y + multiplier*i
            trail_point = Point(x=self.curr_point.x, y=new_y, steps=self.curr_steps)
            self.wire_path.add(trail_point)
            # print("Adding Trail Point: {0}".format(trail_point))

        self.curr_point = Point(
            x=self.curr_point.x,
            y=(self.curr_point.y + magnitude*multiplier),
            steps=self.curr_steps
        )

    def move_horiz(self, magnitude: int, multiplier: int):
        # generate a trail of all traversed points
        for i in range(1, magnitude+1):
            self.curr_steps += 1
            new_x = self.curr_point.x + multiplier*i
            trail_point = Point(x=new_x, y=self.curr_point.y,
                                steps=self.curr_steps)
            self.wire_path.add(trail_point)
            # print("Adding Trail Point: {0}".format(trail_point))

        self.curr_point = Point(
            x=(self.curr_point.x + magnitude*multiplier),
            y=self.curr_point.y,
            steps=self.curr_steps
        )


def get_list_strs_csv(filepath: str) -> List[int]:
    list_wires = []
    with open(filepath) as f:
        for line in f.readlines():
            list_strs = [str(x) for x in line.split(',')]
            list_wires.append(list_strs)

    return list_wires
