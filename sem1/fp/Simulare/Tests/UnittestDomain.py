"""
Python file where we store our class that tests our Domain(Pictura) for the app
"""

import unittest
from Domain.Muzeu import Pictura

class UnittestDomain(unittest.TestCase):

    def setUp(self):
        self.p1 = Pictura(1,"Apus de toamna","Stefan Luchian" , 10)
        self.p2 = Pictura(2,"Apus de iarna" , "Tonitza" , 13)

    def testgetid(self):
        self.assertTrue(self.p1.getid() == 1)
        self.assertTrue(self.p2.getid() == 2)

    def testgetdenumire(self):
        self.assertTrue(self.p1.getdenumire() == "Apus de toamna")
        self.assertTrue(self.p2.getdenumire() == "Apus de iarna")

    def testgetautor(self):
        self.assertTrue(self.p1.getautor() == "Stefan Luchian")
        self.assertTrue(self.p2.getautor() == "Tonitza")

    def testgetnr(self):
        self.assertTrue(self.p1.getnr() == 10)
        self.assertTrue(self.p2.getnr() == 13)
