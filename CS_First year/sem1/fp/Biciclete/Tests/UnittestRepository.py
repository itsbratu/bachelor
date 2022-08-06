"""
Python file where we store our class for repository unittesting
"""

import warnings
import unittest
from Repository.BicicletaRepository import BicicletaRepository
from Domain.Bicicleta import Bicicleta
from Exceptions.Exceptii import NotExistent

class TestRepository(unittest.TestCase):

    def setUp(self):
        warnings.simplefilter('ignore' , ResourceWarning)
        with open("testrepo.txt" , "w") as f:
            f.write("100;Mountain;35.55;")
            f.write("\n")
            f.write("122;Mountain;100;")
            f.write("\n")
            f.write("130;Road;200;")
            f.write("\n")
            f.write("130;Mountain;200;")
            f.write("\n")
            f.write("130;Child;300;")
            f.write("\n")
            f.write("130;Child;300;")
            f.write("\n")
            f.write("130;Child;300;")
            f.write("\n")
        self.repo = BicicletaRepository("testrepo.txt")


    def tearDown(self):
        open("testrepo.txt" , "w").close()

    def testloadfromfile(self):
        list_biciclete = self.repo.loadfromfile()
        self.assertTrue(len(list_biciclete) == 7)

    def testsavetofile(self):
        b1 = Bicicleta(100 , "Mountain" , 25.55)
        b2 = Bicicleta(35 , "Child" , 50.75)

        list_write = []
        list_write.append(b1)
        list_write.append(b2)

        count = 0
        self.repo.savetofile(list_write)
        with open("testrepo.txt" , "r") as f:
            for linie in f:
                if linie != "\n":
                    count = count + 1

        self.assertTrue(count == 2)

    def testgetall(self):
        list_biciclete = []
        self.assertTrue(len(list_biciclete) == 0)
        list_biciclete = self.repo.loadfromfile()
        self.assertTrue(len(list_biciclete) == 7)

    def testdeletebicicleta(self):
        self.assertTrue(len(self.repo.biciclete) == 7)

        self.repo.deletebicicleta("Child")
        self.assertTrue(len(self.repo.biciclete) == 4)

        self.assertRaises(NotExistent , self.repo.deletebicicleta , "Altele")