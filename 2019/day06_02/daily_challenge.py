#!/usr/bin/python3

from __future__ import annotations
from typing import List, Dict, Optional  # also: Dict, Tuple, Sequence, Any, Optional
from dataclasses import dataclass, field


def process_inputfile(filepath: str) -> int:
    list_strs = get_list_strs_csv(filepath)
    return process_orbit_list(list_strs)


def process_orbit_list(list_orbits: List[str]) -> int:
    tree_lookup = build_orbit_tree(list_orbits)
    return count_orbits(tree_lookup)


@dataclass
class Node:
    name: str
    parent: Optional['Node'] = field(default=None, repr=False)
    children: List['Node'] = field(default_factory=list, repr=False)

    def add_child(self, child: 'Node') -> None:
        self.children.append(child)

    def set_parent(self, parent: 'Node') -> None:
        self.parent = parent


def build_orbit_tree(list_orbits: List[str]) -> Dict[str, Node]:
    tree_lookup: Dict[str, Node] = dict()
    for orbit_defn in list_orbits:
        parent_name, child_name = orbit_defn.split(')')
        # print(f"Checking Node Relationship: Parent: {parent_name}; Child: {child_name}")
        try:
            parent_node = tree_lookup[parent_name]
        except KeyError:
            # print(f"Adding New Node: Parent: {parent_name}")
            parent_node = Node(parent_name)
            tree_lookup[parent_name] = parent_node
        try:
            child_node = tree_lookup[child_name]
        except KeyError:
            # print(f"Adding New Node: Child:  {child_name}")
            child_node = Node(child_name)
            tree_lookup[child_name] = child_node
        parent_node.add_child(child_node)
        child_node.set_parent(parent_node)
        # print(f"Parent's Child List is now:  {parent_node.children}")

    return tree_lookup


def count_orbits(orbit_tree_lookup: Dict[str, Node], root_name: str = 'COM'):
    root_node = orbit_tree_lookup[root_name]
    orbit_count = [0]
    count_orbits_inner(root_node, 0, orbit_count)
    return orbit_count[0]


def count_orbits_inner(curr_orbit: Node, depth: int, orbit_count: List[int]) -> None:
    orbit_count[0] += depth
    for child in curr_orbit.children:
        count_orbits_inner(child, depth + 1, orbit_count)


def get_list_strs_csv(filepath: str) -> List[str]:
    list_strs = []
    with open(filepath) as f:
        for line in f.readlines():
            line = line.strip('\n')
            list_strs.append(line)

    return list_strs
