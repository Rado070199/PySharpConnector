import os

def say_hello():
	return "Hi script!"

def test(message):
	directory = os.getcwd()
	return message + ": " + directory