#pragma once
#include <iostream>
#include <random>
#include <string>
#include <cstdlib>
#include <ctime>
#include <assert.h>

std::string random_string(std::string::size_type length)
{
    static auto& chrs = "0123456789"
        "abcdefghijklmnopqrstuvwxyz"
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    thread_local static std::mt19937 rg{ std::random_device{}() };
    thread_local static std::uniform_int_distribution<std::string::size_type> pick(0, sizeof(chrs) - 2);

    std::string s;

    s.reserve(length);

    while (length--)
        s += chrs[pick(rg)];

    return s;
}

int random_int(){
    std::mt19937 mt{ std::random_device{}() };
    std::uniform_int_distribution<> dist(0, 101);
    int rndNr = dist(mt);
    return rndNr;
}

void test_utils() {
    std::string rnd_str = random_string(10);
    assert(rnd_str.size() == 10);

    int nr_generated = random_int();
    assert(nr_generated > 0);
}