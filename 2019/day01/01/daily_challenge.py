#!/usr/bin/python3


def process_inputfile(filepath):
    list_ints = get_list_ints(filepath)

    module_list = []
    total_fuel = 0
    for mass in list_ints:
        fuel_required = calc_fuel_recurse(mass)
        module_list.append(tuple([mass, fuel_required]))
        total_fuel += fuel_required

    return (total_fuel, module_list)


def calc_fuel(mass):
    return int(mass / 3) - 2


def calc_fuel_recurse(mass):
    fuel = 0
    mass = int(mass / 3) - 2
    while mass > 0:
        fuel += mass
        mass = int(mass / 3) - 2
    return fuel


def get_list_ints(filepath):
    list_ints = []
    with open(filepath) as f:
        for line in f.readlines():
            if line:
                list_ints.append(int(line))
    return list_ints
