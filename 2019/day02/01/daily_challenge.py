#!/usr/bin/python3


def process_inputfile(filepath):
    list_ints = get_list_ints_csv(filepath)
    fix_1202_error(list_ints=list_ints)
    process_opcode_space(opcode_space=list_ints)

    return list_ints[0]


def fix_1202_error(list_ints):
    list_ints[1] = 12
    list_ints[2] = 2


def process_opcode_space(opcode_space):
    opcode_halt = 99

    for i in range(0, len(opcode_space), 4):
        if opcode_space[i] == opcode_halt:
            break
        process_opcode(index=i, opcode_space=opcode_space)

    return (opcode_space)


def process_opcode(index, opcode_space):
    opcode = opcode_space[index]
    operand1 = opcode_space[opcode_space[index + 1]]
    operand2 = opcode_space[opcode_space[index + 2]]
    result_store = opcode_space[index + 3]

    opcode_addition = 1
    opcode_multiply = 2

    if (opcode == opcode_addition):
        opcode_space[result_store] = operand1 + operand2
    elif (opcode == opcode_multiply):
        opcode_space[result_store] = operand1 * operand2


def get_list_ints_csv(filepath):
    list_ints = []
    with open(filepath) as f:
        line = f.readline()
        list_ints = [int(x) for x in line.split(',')]
    return list_ints
