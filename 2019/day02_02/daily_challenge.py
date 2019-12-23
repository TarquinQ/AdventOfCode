#!/usr/bin/python3

from typing import List, Callable  # also: Dict, Tuple, Sequence


def process_inputfile(filepath: str) -> int:
    list_ints = get_list_ints_csv(filepath)
    replace_noun_and_verb(list_ints=list_ints, noun=12, verb=2)
    execute_Intcode_program(intcode_memspace=list_ints)

    return list_ints[0]


def process_inputfile_findnounverb(filepath: str, target_val: int) -> int:
    list_ints_orig = get_list_ints_csv(filepath)
    for noun in range(99):
        for verb in range(99):
            list_ints = list_ints_orig.copy()
            replace_noun_and_verb(list_ints=list_ints, noun=noun, verb=verb)
            execute_Intcode_program(intcode_memspace=list_ints)
            if list_ints[0] == target_val:
                return (noun, verb)


def replace_noun_and_verb(list_ints: List[int], noun: int, verb: int) -> None:
    list_ints[1] = noun
    list_ints[2] = verb


def execute_Intcode_program(intcode_memspace: List[int]) -> List[int]:
    instruction_ptr = 0
    while instruction_ptr < len(intcode_memspace):
        requested_opcode = intcode_memspace[instruction_ptr]
        if requested_opcode == instructions.haltcode:
            break
        req_instruct = instructions.lookup(intcode_memspace[instruction_ptr])
        process_instruction(instruct=req_instruct,
                            index=instruction_ptr,
                            intcode_memspace=intcode_memspace)
        instruction_ptr += req_instruct.length

    return (intcode_memspace)


class instruction:
    def __init__(self, name: str, opcode: int, length: int,
                 operand_count: int,
                 operation: Callable[[int, int], int]):
        self.name = name
        self.opcode = opcode
        self.length = length
        self.operand_count = operand_count
        self.operation = operation

    def exec(self, operands: List[int]) -> int:
        return self.operation(operands)


class instructions:
    instruction_list = [
        instruction('halt', 99, 1, 0, lambda x: x),
        instruction('add', 1, 4, 2, lambda x: x[0] + x[1]),
        instruction('multiply', 2, 4, 2, lambda x: x[0] * x[1])
    ]
    opcode_lookup = dict([(instr.opcode, instr) for instr in instruction_list])
    haltcode = 99

    @classmethod
    def lookup(cls, code: int) -> instruction:
        return cls.opcode_lookup[code]


def process_instruction(instruct: instruction, index: int, intcode_memspace: List[int]) -> None:
    if type(instruct) is instruction:
        req_instruct = instruct
        requested_opcode = req_instruct.opcode
    else:
        requested_opcode = intcode_memspace[index]
        req_instruct = instructions.lookup(requested_opcode)

    result_store = intcode_memspace[index + 3]

    operands = []
    for i in range(req_instruct.operand_count):
        operand = intcode_memspace[intcode_memspace[index + 1 + i]]
        operands.append(operand)

    intcode_memspace[result_store] = req_instruct.exec(operands)


def get_list_ints_csv(filepath: str) -> List[int]:
    list_ints = []
    with open(filepath) as f:
        line = f.readline()
        list_ints = [int(x) for x in line.split(',')]
    return list_ints
