"""
Main python file from where we run our application
"""

import unittest

unittest.main(module="Tests.UnittestDomain" , exit = False)
unittest.main(module="Tests.UnittestRepository" , exit = False)
unittest.main(module="Tests.UnittestService" , exit = False)

from Repository.Repository import PicturaRepository
from Service.Service import PicturaService
from Console.Console import Console


repo = PicturaRepository("picturi.txt")
service = PicturaService(repo)
ui = Console(repo , service)

while True:
    try:
        choice = ui.getchoice()
        if not choice:
            break
    except Exception as e:
        print(str(e) + "\n")

print("Thanks for using the app!")