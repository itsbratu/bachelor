"""
Python file where we store our unittest class for the "Elev" instance
"""

import unittest
from Domain.elev import Elev

class TestCaseElev(unittest.TestCase):

    def setUp(self):
        self.e1 = Elev("Bratu" , "Ionut" , 10 , "A")
        self.e2 = Elev("Bratu" , "Andrei" , 12 , "B")

    def testgetnume(self):
        self.assertTrue(self.e1.getnume() == "Bratu")
        self.assertTrue(self.e2.getnume() == "Bratu")

    def testgetprenume(self):
        self.assertTrue(self.e1.getprenume() == "Ionut")
        self.assertTrue(self.e2.getprenume() == "Andrei")

    def testgetnrcls(self):
        self.assertTrue(self.e1.getnrcls() == 10)
        self.assertTrue(self.e2.getnrcls() == 12)

    def testgetnume(self):
        self.assertTrue(self.e1.getnumecls() == "A")
        self.assertTrue(self.e2.getnumecls() == "B")