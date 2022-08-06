"""
Python file from where we execute our application
"""

from Repository.BicicletaRepository import BicicletaRepository
from Service.BicicletaService import BicicletaService
from Console.UI import Console

repo = BicicletaRepository("biciclete.txt")
service = BicicletaService(repo)
ui = Console(repo , service)

import unittest
unittest.main(module="Tests.UnittestRepository" , exit= False)

while True:
    try:
        choice = ui.getchoice()
        if not choice:
            break
    except Exception as e:
        print(str(e) + "\n")

print("Thanks for using the app!")