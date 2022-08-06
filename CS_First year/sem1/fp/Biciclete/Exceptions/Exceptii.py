"""
Python file where we store our custom exceptions for the app
"""

class NotExistent(Exception):
    def __init__(self , msg):
        super().__init__(msg)

class EmptyList(Exception):

    def __init__(self , msg):
        super().__init__(msg)

class InvalidOption(Exception):

    def __init__(self , msg):
        super().__init__(msg)