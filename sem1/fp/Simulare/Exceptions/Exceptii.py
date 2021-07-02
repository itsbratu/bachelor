"""
Python file where we store our custom exceptions as classes
"""

class InvalidCamera(Exception):
    def __init__(self , msg):
        super().__init__(msg)

class InvalidChoice(Exception):
    def __init(self , msg):
        super().__init__(msg)

class InvalidSubstring(Exception):
    def __init(self , msg):
        super().__init__(msg)