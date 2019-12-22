#!/usr/bin/python3

from typing import List, Callable  # also: Dict, Tuple, Sequence


def process_inputfile(filepath):
    list_ints = get_list_ints_csv(filepath)
    replace_noun_and_verb(list_ints=list_ints, noun=12, verb=2)
    execute_Intcode_program(intcode_memspace=list_ints)

    return list_ints[0]


def replace_noun_and_verb(list_ints, noun, verb):
    list_ints[1] = noun
    list_ints[2] = verb


def execute_Intcode_program(intcode_memspace):
    instruction_ptr = 0
    while instruction_ptr < len(intcode_memspace):
        requested_opcode = intcode_memspace[instruction_ptr]
        if requested_opcode == opcodes.haltcode:
            break
        req_op = opcodes.lookup(intcode_memspace[instruction_ptr])
        process_opcode(index=instruction_ptr, intcode_memspace=intcode_memspace)
        instruction_ptr += req_op.instruction_length

    return (intcode_memspace)


class opcode:
    def __init__(self, name: str, code: int, instruction_length: int,
                 operand_count: int, operation: Callable[[int, int], int]):
        self.name = name
        self.code = code
        self.instruction_length = instruction_length
        self.operand_count = operand_count
        self.operation = operation

    def exec(self, operands: List[int]) -> int:
        return self.operation(operands)


class opcodes:
    opcode_list = [
        opcode('halt', 99, 1, 0, lambda x: x),
        opcode('add', 1, 4, 2, lambda x: x[0] + x[1]),
        opcode('multiply', 2, 4, 2, lambda x: x[0] * x[1])
    ]
    opcode_lookup = dict([(opcode.code, opcode) for opcode in opcode_list])
    haltcode = 99

    @classmethod
    def lookup(cls, code: int) -> opcode:
        return cls.opcode_lookup[code]


def process_opcode(index, intcode_memspace):
    requested_opcode = intcode_memspace[index]
    result_store = intcode_memspace[index + 3]

    req_op = opcodes.lookup(requested_opcode)
    operands = []
    for i in range(req_op.operand_count):
        operand = intcode_memspace[intcode_memspace[index + 1 + i]]
        operands.append(operand)

    intcode_memspace[result_store] = req_op.exec(operands)


def get_list_ints_csv(filepath):
    list_ints = []
    with open(filepath) as f:
        line = f.readline()
        list_ints = [int(x) for x in line.split(',')]
    return list_ints
