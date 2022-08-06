"""
Python file where we store our class that tests our PicturaService in app
"""

import unittest
import warnings
from Repository.Repository import PicturaRepository
from Service.Service import PicturaService
from Exceptions.Exceptii import InvalidSubstring , InvalidCamera

class UnittestService(unittest.TestCase):

    def setUp(self):
        warnings.simplefilter('ignore' , ResourceWarning)
        with open("testservice.txt" , "w") as f:
            f.write("1;Toamna pe ulita;Stefan Luchian;13;")
            f.write("\n")
            f.write("2;Iarna;Mark Tonitza;15;")
            f.write("\n")
            f.write("3;Iarna in padure;Tivadar Simona;20;")
            f.write("\n")
            f.write("4;Disperare;Stefan Luchian;10;")
            f.write("\n")
            f.write("5;Dramatic;Bratu Ionut;10;")
            f.write("\n")
        self.repo = PicturaRepository("testservice.txt")
        self.service = PicturaService(self.repo)

    def tearDown(self):
        open("testservice.txt" , "w").close()

    def testcontainsstring(self):
        self.assertTrue(self.service.containsstring("Ionut" , "ut") == True)
        self.assertTrue(self.service.containsstring("Andrei" , "i") == True)
        self.assertFalse(self.service.containsstring("Toamna" , "aagagagaga") == True)
        self.assertFalse(self.service.containsstring("Iarna" , "ABC") == True)

    def testpicturistring(self):
        self.assertRaises(InvalidSubstring , self.service.picturistring , "101f1of1foi21")
        self.assertRaises(InvalidSubstring , self.service.picturistring , "#####")

        list_curr = self.service.picturistring("arna")
        self.assertTrue(len(list_curr) == 2)

        self.assertTrue(list_curr[0].getautor() == "Tivadar Simona")
        self.assertTrue(list_curr[1].getautor() == "Mark Tonitza")

    def testautoricamera(self):
        self.assertRaises(InvalidCamera , self.service.autoricamera , 25)
        self.assertRaises(InvalidCamera , self.service.autoricamera , "d10d101od1")

        list_autori = self.service.autoricamera(10)

        self.assertTrue(list_autori[0] == "Stefan Luchian")
        self.assertTrue(list_autori[1] == "Bratu Ionut")

        self.assertTrue(len(list_autori) == 2)

    def testgetall(self):
        list_picturi = []

        self.assertTrue(len(list_picturi) == 0)
        list_picturi = self.service.getall()

        self.assertTrue(len(list_picturi) == 5)
        self.assertTrue(list_picturi[0].getid() == 1)
        self.assertTrue(list_picturi[1].getnr() == 15)
        self.assertTrue(list_picturi[2].getdenumire() == "Iarna in padure")
        self.assertTrue(list_picturi[3].getid() == 4)
        self.assertTrue(list_picturi[4].getdenumire() == "Dramatic")
