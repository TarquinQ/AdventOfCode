#!/usr/bin/python3

from typing import List, Callable, Any, Optional  # also: Dict, Tuple, Sequence
from dataclasses import dataclass, field
from enum import IntEnum


def process_inputfile(filepath: str) -> int:
    list_ints = get_list_ints_csv(filepath)
#    replace_noun_and_verb(list_ints=list_ints, noun=12, verb=2)
    execute_Intcode_program(intcode_memspace=list_ints)

    return list_ints[0]


def replace_noun_and_verb(list_ints: List[int], noun: int, verb: int) -> None:
    list_ints[1] = noun
    list_ints[2] = verb


def execute_Intcode_program(intcode_memspace: List[int]) -> List[int]:
    instruction_ptr = 0
    while instruction_ptr < len(intcode_memspace):
        opcode_raw = intcode_memspace[instruction_ptr]
        requested_opcode = InstructionType.get_opcode_from_raw(
            raw_code=opcode_raw)
        print(f"InstructionPtr: {instruction_ptr}; RawOpCode: {opcode_raw}; requested_opcode: {requested_opcode}")
        if requested_opcode == InstructionTypes.haltcode:
            print("Halting")
            break
        instruction = Instruction(opcode_raw=opcode_raw,
            instruction_type=InstructionTypes.lookup(requested_opcode),
            instruction_stream=intcode_memspace,
            code_pointer=instruction_ptr)
        print(f"New Instruction: {instruction}")
        result = instruction.exec()
        if instruction.instruction_type.jumps and result != -1:
            instruction_ptr = result
        else:
            instruction_ptr += instruction.instruction_type.length

    return (intcode_memspace)


class ParameterMode(IntEnum):
    POSITION: int = 0
    IMMEDIATE: int = 1


@dataclass
class Parameter:
    operand_value: int
    parameter_mode: ParameterMode = ParameterMode.POSITION
    parameter_value: Optional[int] = None


@dataclass
class InstructionType:
    name: str
    opcode: int
    length: int
    operation: Callable[[Any], Any] = lambda *args: args
    saves: bool = True
    save_operand_position: int = -1  # position of saving operand
    jumps: bool = False

    @staticmethod
    def get_opcode_from_raw(raw_code: int) -> int:
        return abs(raw_code) % 100


@dataclass
class Instruction:
    opcode_raw: int
    instruction_type: InstructionType
    instruction_stream: List[int] = field(repr=False)
    code_pointer: int
    exec_operands: List[Parameter] = field(default_factory=list)
    save_operand: Optional[Parameter] = None

    def __post_init__(self):
        self.operand_count: int = self.instruction_type.length - 1
        self.load_operands()

    def load_operands(self):
        operand_modes = [ParameterMode(int(x)) for x in f"{self.opcode_raw:05d}"[0:3]]
        operand_modes.reverse()
        operand_stream = self.instruction_stream[self.code_pointer + 1:
                                                 self.code_pointer + 1 + self.operand_count]
        if self.instruction_type.saves:
            self.save_operand = Parameter(
                operand_stream.pop(self.instruction_type.save_operand_position)
            )
            operand_modes.pop(self.instruction_type.save_operand_position)

        self.exec_operands = []
        for i, opval in enumerate(operand_stream):
            oper = Parameter(
                operand_value=opval,
                parameter_mode=operand_modes[i],
                parameter_value=opval)
            if oper.parameter_mode == ParameterMode.POSITION:
                oper.parameter_value = self.instruction_stream[opval]
            self.exec_operands.append(oper)

    def exec(self) -> int:
        operand_val_list = []
        for i in self.exec_operands:
            operand_val_list.append(i.parameter_value)
#        print(f"Executing Instruction. Operand Val list: {operand_val_list}")
        if len(operand_val_list) > 0:
            result = self.instruction_type.operation(operand_val_list)  # type: ignore
        else:
            result = self.instruction_type.operation()
        if self.instruction_type.saves:
            self.instruction_stream[self.save_operand.operand_value] = result  # type: ignore
        return result


class InstructionTypes:
    haltcode = 99
    template_list = [
        InstructionType(name='halt', opcode=99, length=1),
        InstructionType(name='add', opcode=1, length=4,
                        operation=(lambda x: x[0] + x[1])),
        InstructionType(name='multiply', opcode=2, length=4,
                        operation=(lambda x: x[0] * x[1])),
        InstructionType(name='input', opcode=3, length=2,
                        operation=(lambda: int(input("Enter Input: ")))),  # type: ignore
        InstructionType(name='output', opcode=4, length=2, saves=False,
                        operation=(lambda x: print(f"Output: {x}"))),
        InstructionType(name='jump-if-true', opcode=5, length=3, saves=False, jumps=True,
                        operation=lambda x: x[1] if (x[0] > 0) else -1),
        InstructionType(name='jump-if-false', opcode=6, length=3, saves=False, jumps=True,
                        operation=(lambda x: x[1] if (x[0] == 0) else -1)),
        InstructionType(name='less-than', opcode=7, length=4,
                        operation=(lambda x: int(x[0] < x[1]))),   # type: ignore
        InstructionType(name='equals', opcode=8, length=4,
                        operation=(lambda x: int(x[0] == x[1]))),  # type: ignore
    ]
    opcode_lookup = dict([(instr.opcode, instr) for instr in template_list])

    @classmethod
    def lookup(cls, code: int) -> InstructionType:
        return cls.opcode_lookup[code]


def get_list_ints_csv(filepath: str) -> List[int]:
    list_ints = []
    with open(filepath) as f:
        line = f.readline()
        list_ints = [int(x) for x in line.split(',')]
    return list_ints
