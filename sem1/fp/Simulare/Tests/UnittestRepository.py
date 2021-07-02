"""
Python file where we store our class that tests our PicturaRepository in app
"""

import unittest
import warnings
from Repository.Repository import PicturaRepository

class UnittestRepository(unittest.TestCase):

    def setUp(self):
        warnings.simplefilter('ignore' , ResourceWarning)
        with open("testrepo.txt" , "w") as f:
            f.write("1;Peisaj de toamna;Stefan Luchian;13;")
            f.write("\n")
            f.write("2;Iarna pe ulita;Tonitza;13;")
            f.write("\n")
            f.write("3;Adormire;Stefan Luchian;14;")
            f.write("\n")
        self.repo = PicturaRepository("testrepo.txt")

    def tearDown(self):
        open("testrepo.txt" , "w").close()

    def testloadfromfile(self):
        list_picturi = []
        self.assertTrue(len(list_picturi) == 0)
        list_picturi = self.repo.loadfromfile()

        self.assertTrue(len(list_picturi) == 3)

    def testgetall(self):
        list_picturi = []
        self.assertTrue(len(list_picturi) == 0)
        list_picturi = self.repo.getall()

        self.assertTrue(len(list_picturi) == 3)
        self.assertTrue(list_picturi[0].getautor() == "Stefan Luchian")
        self.assertTrue(list_picturi[0].getid() == 1)
        self.assertTrue(list_picturi[1].getnr() == 13)
        self.assertTrue(list_picturi[1].getdenumire() == "Iarna pe ulita")
        self.assertTrue(list_picturi[2].getid() == 3)